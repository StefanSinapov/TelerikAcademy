namespace BugLogger.Data.Contracts
{
    using System.Data.Entity;
    using Models;

    public interface IBugLoggerDbContext : IDbContext
    {
        IDbSet<Bug> Bugs { get; set; }
    }
}