namespace LaptopSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using LaptopSystem.Data.Contracts;
    using LaptopSystem.Data.Migrations;
    using LaptopSystem.Data.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class LaptopSystemDbContext : IdentityDbContext<User>, ILaptopSystemDbContext
    {
        public LaptopSystemDbContext()
            : base("name=DefaultConnection(v11.0)", throwIfV1Schema: false)

              // : base("name=DefaultConnection(v12.0)", throwIfV1Schema: false)
              // : base("name=DefaultConnection", throwIfV1Schema: false)
              // See TelerikExamSystem.Web -> Web.config -> connectionStrings
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LaptopSystemDbContext, DefaultMigrationConfiguration>());
        }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<Laptop> Laptops { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Vote> Votes { get; set; }

        public IDbSet<IdentityUserRole> UserRoles { get; set; }

        public static LaptopSystemDbContext Create()
        {
            return new LaptopSystemDbContext();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}