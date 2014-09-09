namespace CarsFactory.MySQL.Models
{
    using System;

    public class Product
    {
        public int ID { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }

        public int ReleaseYear { get; set; }

        public decimal Price { get; set; }
    }
}