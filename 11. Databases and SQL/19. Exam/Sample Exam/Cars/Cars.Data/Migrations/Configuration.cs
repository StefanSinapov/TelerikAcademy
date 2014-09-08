namespace Cars.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Data;

    internal sealed class Configuration : DbMigrationsConfiguration<CarsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}
