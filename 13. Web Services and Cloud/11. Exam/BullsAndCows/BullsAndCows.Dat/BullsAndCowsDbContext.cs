namespace BullsAndCows.Data
{
    using System.Data.Entity;
    using Contracts;
    using Migrations;
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class BullsAndCowsDbContext : IdentityDbContext<User>, IBullsAndCowsDbContext
    {
        public BullsAndCowsDbContext()
            : base("BullsAndCows", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BullsAndCowsDbContext, Configuration>());
        }

        public static BullsAndCowsDbContext Create()
        {
            return new BullsAndCowsDbContext();
        }

        public IDbSet<Game> Games { get; set; }
        public IDbSet<Guess> Guesses { get; set; }
        public IDbSet<Notification> Notifications { get; set; }
    }
}