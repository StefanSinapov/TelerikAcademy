namespace CarsFactory.MongoDb.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Manufacturer
    {
        [BsonConstructor]
        public Manufacturer()
        {
        }

        [BsonConstructor]
        public Manufacturer(int manufacturerId, string name)
        {
            this.ManufacturerId = manufacturerId;
            this.Name = name;
        }
        
        [BsonId]
        public BsonObjectId Id { get; set; }
        
        public int ManufacturerId { get; set; }
        
        public string Name { get; set; }
    }
}