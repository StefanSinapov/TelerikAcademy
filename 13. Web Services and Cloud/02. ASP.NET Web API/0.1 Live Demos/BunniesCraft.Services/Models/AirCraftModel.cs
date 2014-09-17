namespace BunniesCraft.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    using BunniesCraft.Models;

    public class AirCraftModel
    {
        public static Expression<Func<AirCraft, AirCraftModel>> FromAirCraft
        {
            get
            {
                return a => new AirCraftModel
                {
                    Id = a.Id,
                    Model = a.Model
                };
            }
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Model { get; set; }
    }
}