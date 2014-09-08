namespace MongoChat.Models
{
    using MongoDB.Bson.Serialization.Attributes;

    public class User
    {
        public User()
        {
            
        }

        [BsonConstructor]
        public User(string username)
        {
            this.Username = username;
        }

        public string Username { get; set; }
    }
}