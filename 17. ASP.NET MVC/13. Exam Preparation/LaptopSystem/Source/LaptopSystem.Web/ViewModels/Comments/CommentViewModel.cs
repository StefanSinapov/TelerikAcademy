namespace LaptopSystem.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using LaptopSystem.Data.Models;
    using LaptopSystem.Web.Infrastructure.Mapping;

    public class CommentViewModel: IMapFrom<Comment>, IHaveCustomMappings
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 3)]
        public string Content { get; set; }

        public string UserName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(m => m.UserName, opt => opt.MapFrom(c => c.User.UserName));
        }
    }
}