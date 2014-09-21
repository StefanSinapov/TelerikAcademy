namespace MusicStore.Data.Contracts
{
    using Models;

    public interface IMusicStoreData
    {
        IRepository<Song> Songs { get; }

        IRepository<Album> Albums { get; }

        IRepository<Artist> Artists { get; }

        int SaveChanges(); 
    }
}