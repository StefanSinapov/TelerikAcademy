namespace MusicStore.Data.Contracts
{
    using System.Data.Entity;
    using Models;

    public interface IMusicStoreDbContext
    {
        IDbSet<Song> Songs { get; set; }

        IDbSet<Album> Albums { get; set; }

        IDbSet<Artist> Artists { get; set; }

        int SaveChanges();
    }
}