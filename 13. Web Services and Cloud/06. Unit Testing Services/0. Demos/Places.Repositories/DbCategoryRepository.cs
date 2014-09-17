using Places.Models;
using Places.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Places.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
    }

    public class DbCategoryRepository : ICategoryRepository
    {
        private DbContext dbContext;
        private DbSet<Category> entitySet;

        public DbCategoryRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Category>();
        }

        public IQueryable<Category> Find(Expression<Func<Category, int, bool>> predicate)
        {
            return this.entitySet.Where(predicate);
        }

        public Category Add(Category entity)
        {
            this.entitySet.Add(entity);
            this.dbContext.SaveChanges();
            return entity;
        }

        public Category Update(int id, Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var entity = this.entitySet.Find(id);
            if (entity != null)
            {
                this.entitySet.Remove(entity);
                this.dbContext.SaveChanges();
            }
        }

        public Category Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Category> All()
        {
            return this.entitySet;
        }
    }
}