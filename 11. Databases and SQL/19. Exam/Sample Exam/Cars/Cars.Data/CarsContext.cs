namespace Cars.Data
{
    using System.Data.Entity;
    using Contracts;
    using Migrations;
    using Models;

    public class CarsContext: DbContext, ICarsContext
    {

        public CarsContext()
            : base(ConnectionStrings.Default.MsSql)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsContext, Configuration>());
        }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<Car> Cars { get; set; }
        
        public IDbSet<Dealer> Dealers { get; set; }
        
        public IDbSet<City> Cities { get; set; }
    }
}