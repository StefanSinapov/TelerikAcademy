namespace ForumSystem.Data
{
    using System.Data.Entity;
    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models;

    public class ForumSystemDbContext : IdentityDbContext<User>, IForumSystemDbContext
    {
        public ForumSystemDbContext()
            : base("ForumSystem", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ForumSystemDbContext, Configuration>());
        }

        public static ForumSystemDbContext Create()
        {
            return new ForumSystemDbContext();
        }

        public IDbSet<Alert> Alerts { get; set; }
        public IDbSet<Article> Articles { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<Like> Likes { get; set; }
        public IDbSet<Tag> Tags { get; set; }
    }
}