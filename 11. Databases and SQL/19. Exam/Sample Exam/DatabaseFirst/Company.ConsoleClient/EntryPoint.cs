namespace Company.ConsoleClient
{
    using System.Linq;
    using Data;
    using DataGenerators;
    using DataGenerators.Contracts;

    public class EntryPoint
    {
        private static readonly CompanyEntities CompanyEntities = new CompanyEntities();
        private static readonly ILogger ConsoleLogger = new ConsoleLogger();
        private static readonly ISeeder DatabaseSeeder = new DatabaseSeederWithRandomData(CompanyEntities, ConsoleLogger);

        public static void Main()
        {
            using (CompanyEntities)
            {
                ConsoleLogger.Log("Loading...");
                CompanyEntities.Configuration.AutoDetectChangesEnabled = false;

                var isDatabaseCreated = CompanyEntities.Database.CreateIfNotExists();
                if (isDatabaseCreated || !CompanyEntities.Employees.Any())
                {
                    DatabaseSeeder.SeedDatabaseWithRandomData();
                }
            }
        }
    }
}
