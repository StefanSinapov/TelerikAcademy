namespace LaptopSystem.Web.ViewModels.Laptops
{
    using AutoMapper;

    using LaptopSystem.Data.Models;
    using LaptopSystem.Web.Infrastructure.Mapping;

    public class LaptopViewModel : BaseLaptopViewModel, IHaveCustomMappings
    {
        public string ManufacturerName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Laptop, LaptopViewModel>()
                .ForMember(m => m.ManufacturerName, opt => opt.MapFrom(l => l.Manufacturer.Name));
        }
    }
}