namespace BugLogger.Data.Contracts
{
    public interface IBugLoggerData
    {
        IBugRepository Bugs { get; }

        int SaveChanges();
    }
}