namespace ForumSystem.Data
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Models;
    using Repositories;

    public class ForumSystemAlertsData : IForumSystemAlertsData
    {
        private readonly IForumSystemDbContext context;
        private readonly IDictionary<Type, object> repositories = new Dictionary<Type, object>();

        public ForumSystemAlertsData()
            : this(new ForumSystemDbContext())
        {
        }

        public ForumSystemAlertsData(IForumSystemDbContext context)
        {
            this.context = context;
        }

        public IRepository<Alert> Alerts
        {
            get { return this.GetRepository<Alert>(); }
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