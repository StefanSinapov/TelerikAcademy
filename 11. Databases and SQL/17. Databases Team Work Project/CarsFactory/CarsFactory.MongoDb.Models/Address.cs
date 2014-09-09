namespace CarsFactory.MongoDb.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Address
    {
        [BsonConstructor]
        public Address()
        {
        }

        [BsonConstructor]
        public Address(int addressId, string addressText, int townId)
        {
            this.AddressId = addressId;
            this.AddressText = addressText;
            this.TownId = townId;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public int AddressId { get; set; }

        public string AddressText { get; set; }

        public int TownId { get; set; }
    }
}