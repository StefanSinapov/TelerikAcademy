namespace CrowdChat.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using CrowdChat.Common;
    using CrowdChat.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<CrowdChatDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CrowdChatDbContext context)
        {
            this.SeedRoles(context);
            this.SeedUsers(context);
        }

        private void SeedRoles(CrowdChatDbContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            context.Roles.AddOrUpdate(new IdentityRole(GlobalConstants.AdministratorRoleName));
            context.Roles.AddOrUpdate(new IdentityRole(GlobalConstants.ModeratorRoleName));
        }

        private void SeedUsers(CrowdChatDbContext context)
        {
            var user = new User { UserName = "admin@crowdchat.com" };
            context.Users.AddOrUpdate(user);

            // user.Roles.Add();
        }
    }
}
