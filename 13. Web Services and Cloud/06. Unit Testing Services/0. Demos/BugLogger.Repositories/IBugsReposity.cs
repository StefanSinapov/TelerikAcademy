using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugLogger.DataLayer;

namespace BugLogger.Repositories
{
    public interface IBugsReposity : IRepository<Bug>
    {
        Bug Find(int id);

        Bug Add(Bug entity);

        IQueryable<Bug> All();

        void Delete(Bug entity);

        void Update(Bug entity);

        void Save();
    }
}
