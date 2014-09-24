namespace BullsAndCows.Data.Contracts
{
    using System.Data.Entity;
    using Models;

    public interface IBullsAndCowsDbContext
    {
        IDbSet<Game> Games { get; set; }

        IDbSet<Guess> Guesses { get; set; }

        IDbSet<Notification> Notifications { get; set; }

        IDbSet<User> Users { get; set; } 

        int SaveChanges();
    }
}