namespace Cars.XML
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Data.Contracts;
    using Models;
    using Models.Mappings;
    using Newtonsoft.Json;

    public class DataJsonImporter
    {
        private readonly ICarsContext carsContext;

        public DataJsonImporter(ICarsContext carsContext)
        {
            this.carsContext = carsContext;
        }

        public void Import(string directoryPath)
        {

            //TODO: Logger
            Console.WriteLine("Importing cars ");

            var files = Directory.EnumerateFiles(directoryPath);

            foreach (var filePath in files)
            {
                using (var reader = new StreamReader(filePath))
                {
                    string json = reader.ReadToEnd();
                    var cars = JsonConvert.DeserializeObject<List<JsonCar>>(json);

                    foreach (var jCar in cars)
                    {
                        var car = new Car
                        {
                            Model = jCar.Model,
                            Year = jCar.Year,
                            Manufacturer = this.GetOrCreateManufacturer(jCar.ManufacturerName),
                            Price = jCar.Price,
                            Dealer = this.GetOrCreateDealer(jCar.Dealer.Name, jCar.Dealer.City),
                            TransmissionType = this.GetTransmissionType(jCar.TransmissionType)
                        };

                        this.carsContext.Cars.Add(car);
                        this.carsContext.SaveChanges();
                        Console.Write(".");
                    }
                }
            }

            Console.WriteLine("\nCars Imported!\n");
        }

        private TransmissionType GetTransmissionType(int transmissionType)
        {
            if (transmissionType == 0)
            {
                return TransmissionType.Manual;
            }
            return TransmissionType.Automatic;
        }

        private Dealer GetOrCreateDealer(string dealerName, string dealerCity)
        {
            var dealer = this.carsContext.Dealers.FirstOrDefault(d => d.Name == dealerName);

            var city = this.GetOrCreateCityId(dealerCity);

            if (dealer == null)
            {
                dealer = new Dealer
                {
                    Name = dealerName
                };
            }

            dealer.Cities.Add(city);

            return dealer;
        }

        private City GetOrCreateCityId(string dealerCity)
        {
            City city = this.carsContext.Cities.FirstOrDefault(c => c.Name == dealerCity);

            if (city == null)
            {
                city = new City
                {
                    Name = dealerCity
                };
            }

            return city;
        }

        private Manufacturer GetOrCreateManufacturer(string manufacturerName)
        {
            var manufacturer = this.carsContext.Manufacturers.FirstOrDefault(m => m.Name == manufacturerName);

            if (manufacturer == null)
            {
                manufacturer = new Manufacturer
                {
                    Name = manufacturerName
                };
            }

            return manufacturer;
        }
    }
}