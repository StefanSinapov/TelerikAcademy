namespace MusicStore.Data
{
    using System.Data.Entity;
    using Contracts;
    using Migrations;
    using Models;

    public class MusicStoreDbContext : DbContext, IMusicStoreDbContext
    {
        public MusicStoreDbContext()
            : base("MusicStore")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicStoreDbContext, Configuration>());
        }

        public static MusicStoreDbContext Create()
        {
            return new MusicStoreDbContext();
        }

        public IDbSet<Song> Songs { get; set; }

        public IDbSet<Album> Albums { get; set; }

        public IDbSet<Artist> Artists { get; set; }
    }
}