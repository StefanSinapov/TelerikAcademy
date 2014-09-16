namespace TicTacToe.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using TicTacToe.Models;
    using TicTacToe.Data.Migrations;

    public class TicTacToeDbContext : IdentityDbContext<User>
    {
        public TicTacToeDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TicTacToeDbContext, Configuration>());
        }

        public static TicTacToeDbContext Create()
        {
            return new TicTacToeDbContext();
        }

        public IDbSet<Game> Games { get; set; }
    }
}
