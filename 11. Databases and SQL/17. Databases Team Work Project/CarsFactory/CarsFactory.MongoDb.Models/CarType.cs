namespace CarsFactory.MongoDb.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class CarType
    {
        [BsonConstructor]
        public CarType()
        {
        }

        [BsonConstructor]
        public CarType(int carTypeId, string name)
        {
            this.CarTypeId = carTypeId;
            this.Name = name;
        }

        [BsonId]
        public BsonObjectId Id { get; set; }

        public int CarTypeId { get; set; }

        public string Name { get; set; }
    }
}