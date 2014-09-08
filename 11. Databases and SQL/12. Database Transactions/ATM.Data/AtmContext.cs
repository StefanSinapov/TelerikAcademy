namespace ATM.Data
{
    using System.Data.Entity;
    using Migrations;
    using Models;

    public class AtmContext: DbContext
    {
        public AtmContext()
            : base(ConnectionStrings.Default.MSSQLServer)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AtmContext, Configuration>());
        }

        public IDbSet<CardAccount> CardAccounts { get; set; }

        public IDbSet<TransactionsHistory> TransactionsHistories { get; set; } 
    }
}
