namespace TelerikExamSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using TelerikExamSystem.Data.UnitOfWork;
    using TelerikExamSystem.Web.Controllers.Base;

    public class ErrorController : BaseController
    {
        public ErrorController(ITelerikExamSystemData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View("Error");
        }
    }
}