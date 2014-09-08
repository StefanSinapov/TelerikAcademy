namespace Cars.Data.Contracts
{
    using System.Data.Entity;
    using Models;

    public interface ICarsContext
    {
        IDbSet<Manufacturer> Manufacturers { get; set; }

        IDbSet<Car> Cars { get; set; }

        IDbSet<Dealer> Dealers { get; set; }

        IDbSet<City> Cities { get; set; } 

        int SaveChanges();
    }
}