namespace CarsFactory.MongoDb.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Product
    {
        [BsonConstructor]
        public Product()
        {
        }

        [BsonConstructor]
        public Product(int productId, string model, int horsePower, int releaseYear, decimal price, int manufacturerId, int carTypeId, int engineTypeId)
        {
            this.ProductId = productId;
            this.Model = model;
            this.HorsePower = horsePower;
            this.ReleaseYear = releaseYear;
            this.Price = price;
            this.ManufacturerId = manufacturerId;
            this.CarTypeId = carTypeId;
            this.EngineTypeId = engineTypeId;
        }

        [BsonId]
        public BsonObjectId Id { get; set; }

        public int ProductId { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }

        public int ReleaseYear { get; set; }

        public decimal Price { get; set; }

        public int ManufacturerId { get; set; }

        public int CarTypeId { get; set; }

        public int EngineTypeId { get; set; }
    }
}