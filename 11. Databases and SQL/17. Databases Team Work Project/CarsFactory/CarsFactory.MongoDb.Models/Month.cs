namespace CarsFactory.MongoDb.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Month
    {
        [BsonConstructor]
        public Month()
        {
        }

        [BsonConstructor]
        public Month(int monthId, string name)
        {
            this.MonthId = monthId;
            this.Name = name;
        }

        [BsonId]
        public BsonObjectId Id { get; set; }

        public int MonthId { get; set; }

        public string Name { get; set; } 
    }
}