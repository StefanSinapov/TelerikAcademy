namespace TelerikExamSystem.Data.Contracts
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;
    using TelerikExamSystem.Data.Models;

    public interface ITelerikExamSystemDbContext : IDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<IdentityRole> Roles { get; set; }

        IDbSet<IdentityUserRole> UserRoles { get; set; }
    }
}