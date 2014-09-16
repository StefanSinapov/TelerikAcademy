namespace MusicStore.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Contracts;
    using Models;
    using Repository;

    public class MusicStoreData : IMusicStoreData
    {
        private readonly DbContext context;
        private readonly IDictionary<Type, object> repositories;

        public MusicStoreData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Song> Song
        {
            get { return this.GetRepository<Song>(); }
        }

        public IRepository<Album> Album
        {
            get { return this.GetRepository<Album>(); }
        }

        public IRepository<Artist> Artist
        {
            get { return this.GetRepository<Artist>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EfRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}