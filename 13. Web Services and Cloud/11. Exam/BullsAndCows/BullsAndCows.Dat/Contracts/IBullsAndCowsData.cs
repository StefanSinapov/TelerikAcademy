 namespace BullsAndCows.Data.Contracts
 {
     using Models;

     public interface IBullsAndCowsData
     {
         IRepository<Game> Games { get; }
         IRepository<Guess> Guesses { get; }
         IRepository<Notification> Notifications { get; }
         IRepository<User> Users { get; }
         
         int SaveChanges();
     }
 }