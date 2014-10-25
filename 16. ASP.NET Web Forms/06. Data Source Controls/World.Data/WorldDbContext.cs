namespace World.Data
{
    using System.Data.Entity;

    using World.Data.Contracts;
    using World.Data.Migrations;
    using World.Models;

    public class WorldDbContext : DbContext, IWorldDbContext
    {
        public WorldDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<WorldDbContext, Configuration>());
        }

        public static WorldDbContext Create()
        {
            return new WorldDbContext();
        }

        public IDbSet<Town> Towns { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Continent> Continents { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}