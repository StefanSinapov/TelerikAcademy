namespace Company.DataGenerators.Abstract
{
    using Company.Data;
    using Contracts;

    public abstract class DataGenerator : IDataGenerator
    {

        public DataGenerator(CompanyEntities companyEntities, int seedDataCount, ILogger logger)
        {
            this.CompanyEntities = companyEntities;
            this.SeedDataCount = seedDataCount;
            this.Logger = logger;
        }

        public CompanyEntities CompanyEntities { get; set; }

        public ILogger Logger { get; set; }

        public int SeedDataCount { get; set; }

        public abstract void Seed();
    }
}