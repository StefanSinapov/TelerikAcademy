namespace CarsFactory.Loaders
{
    using System.Linq;
    using Data;
    using Models;
    using MongoDB.Data;

    public class MongoDbToSqlLoader
    {
        private readonly MongoDbContext mongoDbContext;
        private readonly CarsFactoryContext carsFactoryContext;

        public MongoDbToSqlLoader(CarsFactoryContext carsFactoryContext, MongoDbContext mongoDbContext)
        {
            this.carsFactoryContext = carsFactoryContext;
            this.mongoDbContext = mongoDbContext;
        }

        public int LoadAll()
        {

            LoadCountries();
            LoadTowns();
            LoadAddresses();
            LoadManufacturers();
            LoadCarTypes();
            LoadEngineTypes();
            LoadDealers();
            LoadProducts();

            return this.carsFactoryContext.SaveChanges();
        }

        private void LoadTowns()
        {
            if (this.carsFactoryContext.Towns.Any())
            {
                return;
            }

            foreach (var town in this.mongoDbContext.Towns.FindAll())
            {
                this.carsFactoryContext.Towns.Add(
                    new Town
                    {
                        Id = town.TownId,
                        Name = town.Name,
                        CountryId = town.CountryId
                    });
            }
        }

        private void LoadAddresses()
        {
            if (this.carsFactoryContext.Addresses.Any())
            {
                return;
            }

            foreach (var address in this.mongoDbContext.Addresses.FindAll())
            {
                this.carsFactoryContext.Addresses.Add(
                    new Address
                    {
                        Id = address.AddressId,
                        AddressText = address.AddressText,
                        TownId = address.TownId
                    });
            }
        }

        private void LoadManufacturers()
        {
            if (this.carsFactoryContext.Manufacturers.Any())
            {
                return;
            }

            foreach (var manufacturer in this.mongoDbContext.Manufacturers.FindAll())
            {
                this.carsFactoryContext.Manufacturers.Add(
                    new Manufacturer
                    {
                        Id = manufacturer.ManufacturerId,
                        Name = manufacturer.Name
                    });
            }
        }

        private void LoadCarTypes()
        {
            if (this.carsFactoryContext.CarTypes.Any())
            {
                return;
            }

            foreach (var carType in this.mongoDbContext.CarTypes.FindAll())
            {
                this.carsFactoryContext.CarTypes.Add(
                    new CarType
                    {
                        Id = carType.CarTypeId,
                        Name = carType.Name
                    });
            }
        }

        private void LoadEngineTypes()
        {
            if (this.carsFactoryContext.EngineTypes.Any())
            {
                return;
            }

            foreach (var engineType in this.mongoDbContext.EngineTypes.FindAll())
            {
                this.carsFactoryContext.EngineTypes.Add(
                    new EngineType
                    {
                        Id = engineType.EngineTypeId,
                        Name = engineType.Name
                    });
            }
        }

        private void LoadDealers()
        {
            if (this.carsFactoryContext.Dealers.Any())
            {
                return;
            }

            foreach (var dealer in this.mongoDbContext.Dealers.FindAll())
            {
                this.carsFactoryContext.Dealers.Add(
                    new Dealer
                    {
                        Id = dealer.DealerId,
                        Name = dealer.Name,
                        AddressId = dealer.AddressId
                    });
            }
        }

        private void LoadProducts()
        {
            if (this.carsFactoryContext.Products.Any())
            {
                return;
            }

            foreach (var product in this.mongoDbContext.Products.FindAll())
            {
                this.carsFactoryContext.Products.Add(
                    new Product
                    {
                        Id = product.ProductId,
                        CarTypeId = product.CarTypeId,
                        EngineTypeId = product.EngineTypeId,
                        HorsePower = product.HorsePower,
                        ManufacturerId = product.ManufacturerId,
                        Model = product.Model,
                        Price = product.Price,
                        ReleaseYear = product.ReleaseYear
                    });
            }
        }

        private void LoadCountries()
        {
            if (this.carsFactoryContext.Countries.Any())
            {
                return;
            }

            foreach (var country in this.mongoDbContext.Countries.FindAll())
            {
                this.carsFactoryContext.Countries.Add(
                    new Country
                    {
                        Id = country.CountryId,
                        Name = country.Name
                    });
            }
        }
    }
}