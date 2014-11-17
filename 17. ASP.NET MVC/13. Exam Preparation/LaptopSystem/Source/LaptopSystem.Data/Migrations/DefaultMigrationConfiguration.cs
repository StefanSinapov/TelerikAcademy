namespace LaptopSystem.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using LaptopSystem.Common;
    using LaptopSystem.Data.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class DefaultMigrationConfiguration : DbMigrationsConfiguration<LaptopSystemDbContext>
    {
        public DefaultMigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LaptopSystemDbContext context)
        {
            this.SeedRoles(context);
            this.SeedAdmin(context);
            this.SeedManufacturers(context);
            this.SeedLaptops(context);
            this.SeedComments(context);
            this.SeedVotes(context);
        }

        private void SeedVotes(LaptopSystemDbContext context)
        {
            if (context.Votes.Any())
            {
                return;
            }

            var user = context.Users.Select(u => u.Id).First();
            var laptops = context.Laptops.Select(l => l.Id);
            var votes = new List<Vote>();

            foreach (var laptop in laptops)
            {
                if (RandomDataGenerator.Instance.GetRandomInt(0, 10) > 5)
                {
                    votes.Add(new Vote
                                  {
                                      LaptopId = laptop,
                                      UserId = user,
                                  });
                }
            }

            context.Votes.AddOrUpdate(votes.ToArray());
            context.SaveChanges();
        }

        private void SeedComments(LaptopSystemDbContext context)
        {
            if (context.Comments.Any())
            {
                return;
            }

            var admin = context.Users.First();

            var laptops = context.Laptops.Select(l => l.Id);
            var comments = new List<Comment>();

            foreach (var laptop in laptops)
            {
                for (int i = 0; i < RandomDataGenerator.Instance.GetRandomInt(0, 4); i++)
                {
                    comments.Add(new Comment
                                     {
                                         LaptopId = laptop,
                                         User = admin,
                                         Content = RandomDataGenerator.Instance.GetRandomString(5, 300)
                                     });
                }
            }

            context.Comments.AddOrUpdate(comments.ToArray());
            context.SaveChanges();
        }

        private void SeedLaptops(LaptopSystemDbContext context)
        {
            if (context.Laptops.Any())
            {
                return;
            }

            var manufacturers = context.Manufacturers.Select(m => m.Id).ToList();

            var laptops = new List<Laptop>();

            foreach (var manufacturer in manufacturers)
            {
                for (int i = 0; i < 10; i++)
                {
                    var laptop = new Laptop
                                     {
                                         ManufacturerId = manufacturer,
                                         Model = RandomDataGenerator.Instance.GetRandomString(4, 20),
                                         Description = RandomDataGenerator.Instance.GetRandomString(4, 20),
                                         AdditionalParts = RandomDataGenerator.Instance.GetRandomString(4, 20),
                                         ImageUrl = GlobalConstants.DefaultImageUrl,
                                         HardDisk = RandomDataGenerator.Instance.GetRandomInt(80, 1000),
                                         Monitor = RandomDataGenerator.Instance.GetRandomInt(9, 21),
                                         Price =
                                             (decimal)
                                             (RandomDataGenerator.Instance.GetRandomInt(500, 2000)
                                              * RandomDataGenerator.Instance.GetRandomDouble()),
                                         Weight = RandomDataGenerator.Instance.GetRandomInt(0, 3)
                                     };
                    context.Laptops.Add(laptop);
                }
            }

            context.SaveChanges();
        }

        private void SeedManufacturers(LaptopSystemDbContext context)
        {
            if (context.Manufacturers.Any())
            {
                return;
            }

            var manufacturers = new List<Manufacturer>
                                    {
                                        new Manufacturer { Name = "Lenovo" },
                                        new Manufacturer { Name = "Toshiba" },
                                        new Manufacturer { Name = "DELL" },
                                        new Manufacturer { Name = "HP" },
                                        new Manufacturer { Name = "Apple" },
                                        new Manufacturer { Name = "Acer" },
                                        new Manufacturer { Name = "ASUS" }
                                    };

            context.Manufacturers.AddOrUpdate(manufacturers.ToArray());
            context.SaveChanges();
        }

        private void SeedAdmin(LaptopSystemDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var userManager = new UserManager<User>(new UserStore<User>(context));
            var admin = new User { UserName = GlobalConstants.AdministratorUserName, };
            admin.Email = admin.UserName;

            userManager.Create(admin, GlobalConstants.AdministratorUserPassword);
            userManager.AddToRole(admin.Id, GlobalConstants.AdministratorRoleName);

            for (int i = 0; i < 10; i++)
            {
                var user = new User
                               {
                                   Email =
                                       string.Format(
                                           "{0}@{1}.com",
                                           RandomDataGenerator.Instance.GetRandomString(6, 16),
                                           RandomDataGenerator.Instance.GetRandomString(6, 16)),
                                   UserName = RandomDataGenerator.Instance.GetRandomString(6, 16)
                               };

                userManager.Create(user, GlobalConstants.AdministratorUserPassword);
            }

            context.SaveChanges();
        }

        private void SeedRoles(LaptopSystemDbContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var adminRole = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
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