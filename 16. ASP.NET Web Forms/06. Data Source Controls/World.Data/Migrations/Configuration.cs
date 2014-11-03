namespace World.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using World.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WorldDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(WorldDbContext context)
        {
            if (!context.Continents.Any())
            {
                SeedContinents(context);
            }

            if (!context.Countries.Any())
            {
                SeedContries(context);
            }

            if (!context.Towns.Any())
            {
                SeedTowns(context);
            }
        }

        private static void SeedTowns(WorldDbContext context)
        {
            context.Towns.AddOrUpdate(
                new Town { Name = "Plovdiv", Population = 112345m, CountryId = 15 },
                new Town { Name = "Sofia", Population = 2312345m, CountryId = 15 },
                new Town { Name = "Berlin", Population = 12346m, CountryId = 13 },
                new Town { Name = "Paris", Population = 12347m, CountryId = 14 });
        }

        private static void SeedContries(WorldDbContext context)
        {
            context.Countries.AddOrUpdate(
                new Country { Name = "Nigeria", Language = "English", Population = 923.768m, ContinentId = 1 },
                new Country { Name = "Egypt", Language = "Arabic", Population = 10001.449m, ContinentId = 1 },
                new Country { Name = "Ghana", Language = "English", Population = 238.534m, ContinentId = 1 },
                new Country { Name = "Japan", Language = "Japanese", Population = 126999.808m, ContinentId = 2 },
                new Country { Name = "China", Language = "Chinese", Population = 1363950000m, ContinentId = 2 },
                new Country { Name = "India", Language = "Hindi", Population = 1236344.631m, ContinentId = 2 },
                new Country { Name = "United States", Language = "English", Population = 316102000m, ContinentId = 3 },
                new Country { Name = "Canada", Language = "English", Population = 35236000m, ContinentId = 3 },
                new Country { Name = "Mexico", Language = "English", Population = 118419000m, ContinentId = 3 },
                new Country { Name = "Brazil", Language = "Portuguese", Population = 201033000m, ContinentId = 4 },
                new Country { Name = "Colombia", Language = "Spanish", Population = 47130000m, ContinentId = 4 },
                new Country { Name = "Peru", Language = "Spanish", Population = 30476000m, ContinentId = 4 },
                new Country { Name = "Germany", Language = "German", Population = 80996685m, ContinentId = 5 },
                new Country { Name = "France", Language = "French", Population = 66259012m, ContinentId = 5 },
                new Country { Name = "Bulgaria", Language = "Bulgarian", Population = 6924716m, ContinentId = 5 },
                new Country { Name = "Australia", Language = "English", Population = 23640800m, ContinentId = 6 });
        }

        private static void SeedContinents(WorldDbContext context)
        {
            context.Continents.AddOrUpdate(
                new Continent { Name = "Africa" },
                new Continent { Name = "Asia" },
                new Continent { Name = "North America" },
                new Continent { Name = "South America" },
                new Continent { Name = "Europe" },
                new Continent { Name = "Australia" },
                new Continent { Name = "Antarctica" });
        }
    }
}
