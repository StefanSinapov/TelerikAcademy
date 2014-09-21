namespace BugLogger.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Contracts;
    using Repositories;
    using Models;

    public class BugLoggerData : IBugLoggerData
    {
        private readonly DbContext context;
        private readonly IDictionary<Type, object> repositories = new Dictionary<Type, object>();

        public BugLoggerData()
            : this(new BugLoggerDbContext())
        {
        }

        public BugLoggerData(DbContext context)
        {
            this.context = context;
        }

        public IBugRepository Bugs
        {
            get
            {
                return (BugRepository)this.GetRepository<Bug>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);

            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var typeOfRepository = typeof(Repository<T>);

                if (typeOfModel.IsAssignableFrom(typeof(Bug)))
                {
                    typeOfRepository = typeof(BugRepository);
                }

                this.repositories.Add(typeOfModel, Activator.CreateInstance(typeOfRepository, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}