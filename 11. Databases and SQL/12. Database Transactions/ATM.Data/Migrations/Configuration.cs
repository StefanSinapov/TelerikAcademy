namespace ATM.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<AtmContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ATM.Data.AtmContext";
        }

        protected override void Seed(AtmContext context)
        {
            if (context.CardAccounts.Any())
            {
                return;
            }

            context.CardAccounts.Add(
                new CardAccount
                {
                    CardNumber = "111-222-33",
                    CardCash = 750.30M,
                    CardPin = "0000"
                });

            context.CardAccounts.Add(
                new CardAccount
                {
                    CardNumber = "333-222-11",
                    CardCash = 1000.00M,
                    CardPin = "1234"
                });
        }
    }
}
