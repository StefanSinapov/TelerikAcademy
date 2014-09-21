namespace BugLogger.Data.Contracts
{
    using System;
    using System.Linq;
    using Models;

    public interface IBugRepository : IRepository<Bug>
    {
        IQueryable<Bug> GetAllByStatus(BugStatus status);

        IQueryable<Bug> GetAllFromDate(DateTime fromDate);

        IQueryable<Bug> GetAllToDate(DateTime toDate);

        IQueryable<Bug> GetAllInDateRange(DateTime fromDate, DateTime toDate);
    }
}