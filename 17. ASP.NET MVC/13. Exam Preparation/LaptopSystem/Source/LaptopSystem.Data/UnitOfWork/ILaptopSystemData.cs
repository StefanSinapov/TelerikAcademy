namespace LaptopSystem.Data.UnitOfWork
{
    using System;
    using System.Data.Entity;

    using LaptopSystem.Data.Contracts;
    using LaptopSystem.Data.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public interface ILaptopSystemData : IDisposable
    {
        DbContext Context { get; }

        IGenericRepository<Manufacturer> Manufacturers { get; }

        IGenericRepository<Laptop> Laptops { get; }

        IGenericRepository<Comment> Comments { get; }

        IGenericRepository<Vote> Votes { get; }

        IGenericRepository<User> Users { get; }

        IGenericRepository<IdentityUserRole> UserRoles { get; }

        IGenericRepository<IdentityRole> Roles { get; }

        int SaveChanges();
    }
}