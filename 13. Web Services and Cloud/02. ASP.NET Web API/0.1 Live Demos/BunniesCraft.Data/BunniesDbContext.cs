namespace BunniesCraft.Data
{
    using System.Data.Entity;

    using BunniesCraft.Models;
    using BunniesCraft.Data.Migrations;

    public class BunniesDbContext : DbContext, IBunniesDbContext
    {
        public BunniesDbContext()
            : base("BunniesCraftConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BunniesDbContext, Configuration>());
        }

        public virtual IDbSet<Bunny> Bunnies { get; set; }

        public virtual IDbSet<AirCraft> AirCrafts { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
