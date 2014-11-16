namespace TelerikExamSystem.Data.UnitOfWork
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using TelerikExamSystem.Data.Contracts;
    using TelerikExamSystem.Data.Models;

    public interface ITelerikExamSystemData : IDisposable
    {
        DbContext Context { get; }

        IGenericRepository<User> Users { get; }

        IGenericRepository<IdentityUserRole> UserRoles { get; }

        IGenericRepository<IdentityRole> Roles { get; }

        int SaveChanges();
    }
}