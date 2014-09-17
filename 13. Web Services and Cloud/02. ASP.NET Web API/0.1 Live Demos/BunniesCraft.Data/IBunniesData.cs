namespace BunniesCraft.Data
{
    using BunniesCraft.Data.Repositories;
    using BunniesCraft.Models;

    public interface IBunniesData
    {
        IRepository<Bunny> Bunnies { get; }

        IRepository<AirCraft> AirCrafts { get; }

        void SaveChanges();
    }
}
