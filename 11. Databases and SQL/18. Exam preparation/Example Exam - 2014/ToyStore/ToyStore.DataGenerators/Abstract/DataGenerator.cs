namespace ToyStore.DataGenerators.Abstract
{
    using Contracts;
    using Data;

    public abstract class DataGenerator : IDataGenerator
    {

        public DataGenerator(ToyStoreEntities toyStoreEntities, int seedDataCount, ILogger logger)
        {
            this.ToyStoreEntities = toyStoreEntities;
            this.SeedDataCount = seedDataCount;
            this.Logger = logger;
        }

        public ToyStoreEntities ToyStoreEntities { get; set; }

        public ILogger Logger { get; set; }

        public int SeedDataCount { get; set; }

        public abstract void Seed();
    }
}