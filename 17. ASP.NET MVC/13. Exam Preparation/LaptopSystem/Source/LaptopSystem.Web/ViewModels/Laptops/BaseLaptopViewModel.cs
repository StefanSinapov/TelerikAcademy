namespace LaptopSystem.Web.ViewModels.Laptops
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using LaptopSystem.Data.Models;
    using LaptopSystem.Web.Infrastructure.Mapping;

    public abstract class BaseLaptopViewModel : IMapFrom<Laptop>
    {
        public int? Id { get; set; }

        public string Model { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }
    }
}