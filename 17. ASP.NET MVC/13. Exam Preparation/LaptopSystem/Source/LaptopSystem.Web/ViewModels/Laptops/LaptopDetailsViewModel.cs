namespace LaptopSystem.Web.ViewModels.Laptops
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using AutoMapper;

    using LaptopSystem.Data.Models;
    using LaptopSystem.Web.Infrastructure.Mapping;
    using LaptopSystem.Web.ViewModels.Comments;

    public class LaptopDetailsViewModel : BaseLaptopViewModel, IHaveCustomMappings
    {
        [Required]
        public int Monitor { get; set; }

        [Required]
        public int HardDisk { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public int VotesCount { get; set; }

        public int? Weight { get; set; }

        public string AdditionalParts { get; set; }

        public string Description { get; set; }

        public string ManufacturerName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Laptop, LaptopDetailsViewModel>()
                .ForMember(m => m.ManufacturerName, opt => opt.MapFrom(l => l.Manufacturer.Name))
                .ForMember(m => m.VotesCount, opt => opt.MapFrom(l => l.Votes.Count))
                .ForMember(
                    m => m.Comments,
                    opt => opt.MapFrom(l => l.Comments.Select(c => new CommentViewModel
                                                                       {
                                                                           Content = c.Content,
                                                                           Id = c.Id,
                                                                           UserName = c.User.UserName
                                                                       })));
        }
    }
}