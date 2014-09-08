namespace MongoChat.Data
{
    using Models;
    using MongoDB.Driver;

    public class MongoChatContext
    {
        private readonly string connectionString;
        private readonly string databaseName;
        private MongoServer mongoServer;

        public MongoChatContext()
            : this(MongoChat.Default.ConnectionString, MongoChat.Default.DatabaseName)
        {
            
        }

        public MongoChatContext(string connectionString, string databaseName)
        {
            this.connectionString = connectionString;
            this.databaseName = databaseName;
        }

        public MongoCollection<Message> Messages
        {
            get { return this.GetCollection<Message>("Messages"); }
        }

        private MongoCollection<T> GetCollection<T>(string collectionName)
        {
            var database = this.GetDatabase();
            return database.GetCollection<T>(collectionName);
        }

        private MongoDatabase GetDatabase()
        {
            var server = this.GetServer();
            return server.GetDatabase(this.databaseName);
        }

        private MongoServer GetServer()
        {
            if (this.mongoServer == null)
            {
                var mongoClient = new MongoClient(this.connectionString);
                this.mongoServer = mongoClient.GetServer();
            }

            return this.mongoServer;
        }
    }
}