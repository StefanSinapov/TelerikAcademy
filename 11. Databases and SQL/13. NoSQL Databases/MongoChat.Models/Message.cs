namespace MongoChat.Models
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Message
    {
        [BsonConstructor]
        public Message()
        {
            
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Text { get; set; }

        public DateTime PostDate { get; set; }

        public User User { get; set; }


        public override string ToString()
        {
            string formatDate = this.PostDate.ToString("dd.MM.yyyy hh:mm:ss");
            var result = string.Format("[{0}] {1}: {2}", formatDate, this.User.Username, this.Text);
            return result;
        }
    }
}

/*{
    "_id": {
        "$oid": "540a42e5e4b06545e8050d4d"
    },
    "Text": "Message text here",
    "PostDate": "2014-09-06",
    "User": {
        "Username": "Pesho"
    }
}*/