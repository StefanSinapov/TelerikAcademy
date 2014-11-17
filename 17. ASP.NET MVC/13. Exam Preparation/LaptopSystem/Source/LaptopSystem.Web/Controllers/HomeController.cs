namespace LaptopSystem.Web.Controllers
{
    using System.Web.Mvc;

    using LaptopSystem.Web.Infrastructure.Services.Contracts;

    public class HomeController : Controller
    {
        private readonly IHomeService service;

        public HomeController(IHomeService service)
        {
            this.service = service;
        }

        [OutputCache(Duration = 1 * 60 * 60)]
        public ActionResult Index()
        {
            return this.View(this.service.GetIndexViewModel(6));
        }
    }
}