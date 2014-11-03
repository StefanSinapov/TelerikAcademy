 namespace World.Data.Contracts
{
    using World.Models;

    public interface IWorldData
    {
        // IRepository<Model> Models { get; }
        IRepository<Town> Towns { get; }

        IRepository<Country> Countries { get; }

        IRepository<Continent> Continents { get; }

        int SaveChanges();
    }
}