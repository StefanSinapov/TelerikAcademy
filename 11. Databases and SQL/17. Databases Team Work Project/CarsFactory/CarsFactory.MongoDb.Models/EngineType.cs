namespace CarsFactory.MongoDb.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class EngineType
    {
        [BsonConstructor]
        public EngineType()
        {
        }

        [BsonConstructor]
        public EngineType(int engineTypeId, string name)
        {
            this.EngineTypeId = engineTypeId;
            this.Name = name;
        }
         
        [BsonId]
        public BsonObjectId Id { get; set; }

        public int EngineTypeId { get; set; }

        public string Name { get; set; }
    }
}