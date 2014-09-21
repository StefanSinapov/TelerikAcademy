namespace Project.Data
{
    using System.Data.Entity;
    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models;

    public class ProjectDbContext : IdentityDbContext<User>, IProjectDbContext
    {
        public ProjectDbContext()
            : base("AppHarbor", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProjectDbContext, Configuration>());
        }

        public static ProjectDbContext Create()
        {
            return new ProjectDbContext();
        }
		
    }
}