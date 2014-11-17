namespace LaptopSystem.Web.Areas.Admin.ViewModels.Laptops
{
    using System.ComponentModel.DataAnnotations;

    using LaptopSystem.Web.ViewModels.Laptops;

    public class LaptopViewModel : BaseLaptopViewModel
    {
        [Required]
        public int Monitor { get; set; }

        [Required]
        public int HardDisk { get; set; }

        public int? Weight { get; set; }

        public string AdditionalParts { get; set; }

        public string Description { get; set; }

        public int ManufacturerId { get; set; }
    }
}