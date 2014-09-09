namespace CarsFactory.MongoDb.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Country
    {
        [BsonConstructor]
        public Country()
        {
        }

        [BsonConstructor]
        public Country(int countryId, string name)
        {
            this.CountryId = countryId;
            this.Name = name;
        }

        [BsonId]
        public BsonObjectId Id { get; set; }

        public int CountryId { get; set; }

        public string Name { get; set; } 
    }
}