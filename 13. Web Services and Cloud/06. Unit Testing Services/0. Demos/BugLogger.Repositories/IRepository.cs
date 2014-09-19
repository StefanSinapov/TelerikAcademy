using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugLogger.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);

        T Find(int id);

        IQueryable<T> All();

        void Delete(T entity);

        void Update(T entity);

        void Save();
    }
}
