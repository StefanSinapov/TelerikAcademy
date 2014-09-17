using Places.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Places.Services.Tests.Fakes
{
    class FakeRepository<T> : IRepository<T> where T:class
    {
      public  IList<T> entities = new List<T>();

        public T Add(T entity)
        {
            this.entities.Add(entity);
            return entity;
        }
        public T Get(int id)
        {
            return this.entities[id];
        }

        public IQueryable<T> All()
        {
            return this.entities.AsQueryable();
        }

        public T Update(int id, T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Find(Expression<Func<T, int, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
