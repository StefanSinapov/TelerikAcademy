namespace World.Data.Contracts
{
    using System;
    using System.Data.Entity;

    using World.Models;

    public interface IWorldDbContext : IDbContext
    {
        // IDbSet<Feedback> Feedbacks { get; set; }
        IDbSet<Town> Towns { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<Continent> Continents { get; set; } 
    }
}