namespace BullsAndCows.Data.Contracts
{
    using Models;

    public interface IBullsAndCowsUsersData
    {
        IRepository<User> Users { get; }

        int SaveChanges(); 
    }
}