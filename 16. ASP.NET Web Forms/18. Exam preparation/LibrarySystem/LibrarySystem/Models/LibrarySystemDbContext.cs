namespace LibrarySystem.Models
{
    using System.Data.Entity;

    using LibrarySystem.Migrations;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class LibrarySystemDbContext : IdentityDbContext<User>
    {
        public LibrarySystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LibrarySystemDbContext, Configuration>());
        }

        public static LibrarySystemDbContext Create()
        {
            return new LibrarySystemDbContext();
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Category> Categories { get; set; }
    }
}