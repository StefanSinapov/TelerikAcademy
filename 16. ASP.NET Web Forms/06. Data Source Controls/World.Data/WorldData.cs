namespace World.Data
{
    using System;
    using System.Collections.Generic;

    using World.Data.Contracts;
    using World.Data.Repositories;
    using World.Models;

    public class WorldData : IWorldData
    {
        private readonly IWorldDbContext context;
        private readonly IDictionary<Type, object> repositories = new Dictionary<Type, object>();

        public WorldData()
            : this(new WorldDbContext())
        {
        }

        public WorldData(IWorldDbContext context)
        {
            this.context = context;
        }

        public IRepository<Town> Towns
        {
            get
            {
                return this.GetRepository<Town>();
            }
        }

        public IRepository<Country> Countries
        {
            get
            {
                return this.GetRepository<Country>();
            }
        }

        public IRepository<Continent> Continents
        {
            get
            {
                return this.GetRepository<Continent>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);

            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var typeOfRepository = typeof(Repository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(typeOfRepository, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}