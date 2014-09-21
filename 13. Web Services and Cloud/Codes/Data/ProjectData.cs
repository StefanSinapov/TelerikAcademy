namespace Project.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Project.Data.Contracts;
    using Project.Data.Repositories;

    public class ProjectData : IProjectData
    {
        private readonly IProjectDbContext context;
        private readonly IDictionary<Type, object> repositories = new Dictionary<Type, object>();

        public ProjectData()
            : this(new ProjectDbContext())
        {
        }

        public ProjectData(IProjectDbContext context)
        {
            this.context = context;
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