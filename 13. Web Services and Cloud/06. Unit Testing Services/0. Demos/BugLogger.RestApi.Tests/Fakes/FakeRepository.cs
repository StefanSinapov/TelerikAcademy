using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugLogger.Repositories;

namespace BugLogger.RestApi.Tests.Fakes
{
    public class FakeRepository<T>:IRepository<T>
    {
        public IList<T> Entities { get; set; }
        public T Add(T entity)
        {
            this.Entities.Add(entity);
            return entity;
        }

        public T Find(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> All()
        {
            return this.Entities.AsQueryable();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            this.IsSaveCalled = true;
        }

        public bool IsSaveCalled { get; set; }
    }
}
