using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories
{
    interface IRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Add(T item);
        void Delete(T item);
        void Update(T item);
    }
}
