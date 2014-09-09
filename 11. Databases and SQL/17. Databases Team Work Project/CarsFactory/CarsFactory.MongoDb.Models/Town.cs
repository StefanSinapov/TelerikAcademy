namespace CarsFactory.MongoDb.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Town
    {
        [BsonConstructor]
        public Town()
        {
        }

        [BsonConstructor]
        public Town(int townId, string name, int countryId)
        {
            this.TownId = townId;
            this.Name = name;
            this.CountryId = countryId;
        }

        [BsonId]
        public BsonObjectId Id { get; set; }
        
        public int TownId { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }
    }
}