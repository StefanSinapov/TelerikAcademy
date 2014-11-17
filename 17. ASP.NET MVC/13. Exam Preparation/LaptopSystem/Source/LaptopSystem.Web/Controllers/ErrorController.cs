namespace LaptopSystem.Web.Controllers
{
    using System.Web.Mvc;

    using LaptopSystem.Data.UnitOfWork;
    using LaptopSystem.Web.Controllers.Base;

    public class ErrorController : BaseController
    {
        public ErrorController(ILaptopSystemData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View("Error");
        }
    }
}