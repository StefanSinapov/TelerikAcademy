namespace ToyStore.DataGenerators
{
    using System.Collections.Generic;
    using Contracts;
    using Data;
    using ModelGenerators;

    public class DatabaseSeederWithRandomData : ISeeder
    {
        private const int CategoriesCount = 100;
        private const int ManufacturersCount = 50;
        private const int AgeRangesCount = 100;
        private const int ToysCount = 20000;

        public DatabaseSeederWithRandomData(ToyStoreEntities toyStoreEntities, ILogger logger)
        {
            this.ToyStoreEntities = toyStoreEntities;
            this.Logger = logger;
        }

        private ToyStoreEntities ToyStoreEntities{ get; set; }

        private ILogger Logger { get; set; }

        public void SeedDatabaseWithRandomData()
        {
            var dataGenerators = new HashSet<IDataGenerator>
            {
                new AgeRangeGenerator(this.ToyStoreEntities, AgeRangesCount, this.Logger),
                new CategoryGenerator(this.ToyStoreEntities, CategoriesCount, this.Logger),
                new ManufacturerGenerator(this.ToyStoreEntities, ManufacturersCount, this.Logger),
                new ToyGenerator(this.ToyStoreEntities, ToysCount, this.Logger)
            };

            foreach (var dataGenerator in dataGenerators)
            {
                dataGenerator.Seed();
            }
        }
    }
}