namespace ToyStore.ConsoleClient
{
    using System.Linq;
    using Data;
    using DataGenerators;
    using DataGenerators.Contracts;

    public class EntryPoint
    {
        private static readonly ToyStoreEntities ToyStoreEntities = new ToyStoreEntities();
        private static readonly ILogger ConsoleLogger = new ConsoleLogger();
        private static readonly ISeeder DatabaseSeeder = new DatabaseSeederWithRandomData(ToyStoreEntities, ConsoleLogger);

        public static void Main()
        {
            using (ToyStoreEntities)
            {
                ToyStoreEntities.Configuration.AutoDetectChangesEnabled = false;

                var isDatabaseCreated = ToyStoreEntities.Database.CreateIfNotExists();
                if (isDatabaseCreated || !ToyStoreEntities.Toys.Any())
                {
                    DatabaseSeeder.SeedDatabaseWithRandomData();
                }
            }
        }
    }
}
