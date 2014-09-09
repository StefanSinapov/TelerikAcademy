namespace CarsFactory.MongoDB.Data
{
    using System.Configuration;
    using MongoDb.Models;
    using global::MongoDB.Driver;

    public class MongoDbContext
    {
        private const string DefaultDatabaseName = "carsfactory";

        public MongoDbContext()
            : this(ConfigurationManager.ConnectionStrings["CarsFactoryMongo"].ConnectionString, DefaultDatabaseName)
        {
        }

        public MongoDbContext(string connectionString, string databaseName)
        {
            var mongoClient = new MongoClient(connectionString);
            var mongoServer = mongoClient.GetServer();
            this.Database = mongoServer.GetDatabase(databaseName);
        }

        public MongoCollection<Expense> Expenses
        {
            get { return this.Database.GetCollection<Expense>("Expenses"); }
        }

        public MongoCollection<Country> Countries
        {
            get { return this.Database.GetCollection<Country>("Countries"); }
        }

        public MongoCollection<Address> Addresses
        {
            get { return this.Database.GetCollection<Address>("Addresses"); }
        }

        public MongoCollection<CarType> CarTypes
        {
            get { return this.Database.GetCollection<CarType>("CarTypes"); }
        }

        public MongoCollection<Dealer> Dealers
        {
            get { return this.Database.GetCollection<Dealer>("Dealers"); }
        }

        public MongoCollection<EngineType> EngineTypes
        {
            get { return this.Database.GetCollection<EngineType>("EngineTypes"); }
        }

        public MongoCollection<Manufacturer> Manufacturers
        {
            get { return this.Database.GetCollection<Manufacturer>("Manufacturers"); }
        }

        public MongoCollection<Month> Months
        {
            get { return this.Database.GetCollection<Month>("Months"); }
        }
        
        public MongoCollection<Product> Products
        {
            get { return this.Database.GetCollection<Product>("Products"); }
        }

        public MongoCollection<Town> Towns
        {
            get { return this.Database.GetCollection<Town>("Towns"); }
        }

        private MongoDatabase Database { get; set; }
    }
}