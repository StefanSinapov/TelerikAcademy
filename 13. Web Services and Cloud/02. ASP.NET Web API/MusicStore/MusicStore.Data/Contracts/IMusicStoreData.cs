namespace MusicStore.Data.Contracts
{
    using Models;
    using Repository;

    public interface IMusicStoreData
    {
        IRepository<Song> Song { get; }

        IRepository<Album> Album { get; }

        IRepository<Artist> Artist { get; }

        int SaveChanges(); 
    }
}