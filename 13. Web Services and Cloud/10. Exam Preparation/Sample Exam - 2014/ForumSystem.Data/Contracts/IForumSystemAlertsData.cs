namespace ForumSystem.Data.Contracts
{
    using Models;

    public interface IForumSystemAlertsData
    {
        IRepository<Alert> Alerts { get; }

        int SaveChanges();
    }
}