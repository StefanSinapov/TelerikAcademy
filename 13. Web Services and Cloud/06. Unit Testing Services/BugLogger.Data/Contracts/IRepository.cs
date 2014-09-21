namespace BugLogger.Data.Contracts
{
    using System.Linq;

    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();

        T Find(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(int id);

        void Detach(T entity);

        void SaveChanges();
    }
}