namespace Project.Data.Contracts
{
    using System.Data.Entity;
    using Models;

    public interface IFeedbackSystemDbContext
    {
        // IDbSet<Feedback> Feedbacks { get; set; }

        int SaveChanges();
    }
}