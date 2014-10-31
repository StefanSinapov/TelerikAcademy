namespace CrowdChat.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using CrowdChat.Common;
    using CrowdChat.Models;

    using Microsoft.AspNet.Identity;
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
            // this.SeedRoles(context);
            // this.SeedUsers(context);
            context.Configuration.LazyLoadingEnabled = true;

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<User>(new UserStore<User>(context));

            // Admin and Administrator Role
            if (!roleManager.RoleExists(GlobalConstants.AdministratorRoleName))
            {
                roleManager.Create(new IdentityRole(GlobalConstants.AdministratorRoleName));
            }

            var user = new User { UserName = GlobalConstants.AdministratorUserName };
            user.Email = user.UserName;

            if (userManager.FindByName(GlobalConstants.AdministratorUserName) == null)
            {
                var result = userManager.Create(user, GlobalConstants.AdministratorPassword);

                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);
                }
            }

            // Moderator and Moderator Role
            if (!roleManager.RoleExists(GlobalConstants.ModeratorRoleName))
            {
                roleManager.Create(new IdentityRole(GlobalConstants.ModeratorRoleName));
            }

            var userModerator = new User { UserName = GlobalConstants.ModeratorUserName };
            userModerator.Email = userModerator.UserName;

            if (userManager.FindByName(GlobalConstants.ModeratorUserName) == null)
            {
                var result = userManager.Create(userModerator, GlobalConstants.ModeratorPassword);

                if (result.Succeeded)
                {
                    userManager.AddToRole(userModerator.Id, GlobalConstants.ModeratorRoleName);
                }
            }
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
