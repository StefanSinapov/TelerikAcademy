namespace LaptopSystem.Web.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using LaptopSystem.Data.UnitOfWork;
    using LaptopSystem.Web.Controllers.Base;
    using LaptopSystem.Web.ViewModels.Laptops;

    public class LaptopsController : BaseController
    {
        public LaptopsController(ILaptopSystemData data)
            : base(data)
        {
        }

        public ActionResult Details(int id)
        {
            var laptop = this.Data.Laptops
                .All()
                .Where(l => l.Id == id)
                .Project()
                .To<LaptopDetailsViewModel>()
                .FirstOrDefault();

            if (laptop == null)
            {
                throw new HttpException(404, "Laptop not found");
            }

            return this.View(laptop);
        }

        public class SearchOptionsViewModel
        {
            public string Model { get; set; }

            public string Manufacturer { get; set; }

            public decimal? Price { get; set; }
        }

        [HttpGet]
        [Authorize]
        public ActionResult All(SearchOptionsViewModel searchOptions)
        {
            return this.View(searchOptions);
        }

        [Authorize]
        [HttpPost]
        public ActionResult GetLaptops([DataSourceRequest]DataSourceRequest request, SearchOptionsViewModel searchOptions)
        {
            var laptops = this.Data.Laptops.All();

            if (searchOptions.Model != null)
            {
                laptops = laptops.Where(l => l.Model.Contains(searchOptions.Model));
            }

            if (searchOptions.Manufacturer != null)
            {
                laptops = laptops.Where(l => l.Manufacturer.Name.Contains(searchOptions.Manufacturer));
            }

            if (searchOptions.Price != null)
            {
                laptops = laptops.Where(l => l.Price <= searchOptions.Price);
            }

            var result = laptops.Project().To<LaptopViewModel>();

            return this.Json(result.ToDataSourceResult(request));
        }

        [Authorize]
        public ActionResult GetModels()
        {
            var models = this.Data.Laptops.All().Select(m => m.Model);

            return this.Json(models, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 1 * 60 * 60)]
        public ActionResult GetManufacturers()
        {
            var result = this.Data.Manufacturers.All().Select(m => m.Name).ToList();
            result.Add("All");

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}