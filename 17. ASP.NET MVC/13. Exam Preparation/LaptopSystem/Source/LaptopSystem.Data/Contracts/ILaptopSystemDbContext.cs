namespace LaptopSystem.Data.Contracts
{
    using System.Data.Entity;

    using LaptopSystem.Data.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public interface ILaptopSystemDbContext : IDbContext
    {
        IDbSet<Manufacturer> Manufacturers { get; set; }

        IDbSet<Laptop> Laptops { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Vote> Votes { get; set; }

        IDbSet<User> Users { get; set; }

        IDbSet<IdentityRole> Roles { get; set; }

        IDbSet<IdentityUserRole> UserRoles { get; set; }
    }
}