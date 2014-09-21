namespace BugLogger.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BugLoggerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BugLoggerDbContext context)
        {
            if (context.Bugs.Any())
            {
                return;
            }

            const int numberOfBugsToSeed = 1000;

            for (int i = 0; i < numberOfBugsToSeed; i++)
            {
                var bug = new Bug
                {
                    Description = "bug report" + i,
                    LogDate = DateTime.Now.AddDays(i),
                    Status = (BugStatus)(i%3)
                };

                context.Bugs.Add(bug);
            }

            context.SaveChanges();
        }
    }
}
