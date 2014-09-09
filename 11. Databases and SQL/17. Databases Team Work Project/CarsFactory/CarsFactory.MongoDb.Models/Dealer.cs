namespace CarsFactory.MongoDb.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Dealer
    {
        [BsonConstructor]
        public Dealer()
        {
        }

        [BsonConstructor]
        public Dealer(int dealerId, string name, int addressId)
        {
            this.DealerId = dealerId;
            this.Name = name;
            this.AddressId = addressId;
        }

        [BsonId]
        public BsonObjectId Id { get; set; }

        public int DealerId { get; set; }

        public string Name { get; set; }

        public int AddressId { get; set; }
    }
}