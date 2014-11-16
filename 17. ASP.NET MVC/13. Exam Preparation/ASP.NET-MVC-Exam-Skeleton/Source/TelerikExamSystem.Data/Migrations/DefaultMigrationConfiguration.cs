namespace TelerikExamSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using TelerikExamSystem.Common;
    using TelerikExamSystem.Data;
    using TelerikExamSystem.Data.Models;

    internal sealed class DefaultMigrationConfiguration : DbMigrationsConfiguration<TelerikExamSystemDbContext>
    {
        public DefaultMigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TelerikExamSystemDbContext context)
        {
            // this.SeedRoles(context);
            // this.SeedAdmin(context);
        }

        private void SeedAdmin(TelerikExamSystemDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var userManager = new UserManager<User>(new UserStore<User>(context));
            var admin = new User()
            {
                UserName = "admin@gmail.com",
            };

            userManager.Create(admin, "admin@gmail.com");
            userManager.AddToRole(admin.Id, "Admin");

            for (int i = 0; i < 10; i++)
            {
                var user = new User
                               {
                                   Email = string.Format(
                                           "{0}@{1}.com",
                                           RandomDataGenerator.Instance.GetRandomString(6, 16),
                                           RandomDataGenerator.Instance.GetRandomString(6, 16)),
                                   UserName = RandomDataGenerator.Instance.GetRandomString(6, 16)
                               };

                userManager.Create(user, "123456");
            }

            context.SaveChanges();
        }

        private void SeedRoles(TelerikExamSystemDbContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var adminRole = new IdentityRole { Name = "Admin" };
            roleManager.Create(adminRole);

            context.SaveChanges();
        }

        private Image GetDefaultImage()
        {
            var directory = AssemblyHelpers.GetDirectoryForAssembly(Assembly.GetExecutingAssembly());
            var file = File.ReadAllBytes(directory + "/Images/default.png");
            var image = new Image
            {
                Content = file,
                FileExtension = "png"
            };

            return image;
        }
    }
}