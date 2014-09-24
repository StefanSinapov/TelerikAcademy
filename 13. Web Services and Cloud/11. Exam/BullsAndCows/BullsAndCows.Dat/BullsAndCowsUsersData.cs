namespace BullsAndCows.Data
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Models;
    using Repositories;

    public class BullsAndCowsUsersData : IBullsAndCowsUsersData
    {
        private readonly IBullsAndCowsDbContext context;
        private readonly IDictionary<Type, object> repositories = new Dictionary<Type, object>();

        public BullsAndCowsUsersData()
            : this(new BullsAndCowsDbContext())
        {
        }

        public BullsAndCowsUsersData(IBullsAndCowsDbContext context)
        {
            this.context = context;
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
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