namespace ForumSystem.Data
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Repositories;
    using Models;

    public class ForumSystemData : IForumSystemData
    {
        private readonly IForumSystemDbContext context;
        private readonly IDictionary<Type, object> repositories = new Dictionary<Type, object>();

        public ForumSystemData()
            : this(new ForumSystemDbContext())
        {
        }

        public ForumSystemData(IForumSystemDbContext context)
        {
            this.context = context;
        }

        public IRepository<Alert> Alerts
        {
            get { return this.GetRepository<Alert>(); }
        }

        public IRepository<Article> Articles
        {
            get { return this.GetRepository<Article>(); }
        }

        public IRepository<Category> Categories
        {
            get { return this.GetRepository<Category>(); }
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public IRepository<Like> Likes
        {
            get { return this.GetRepository<Like>(); }
        }

        public IRepository<Tag> Tags
        {
            get { return this.GetRepository<Tag>(); }
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