namespace TelerikExamSystem.Web.Controllers.Base
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;
    using TelerikExamSystem.Data.Models;
    using TelerikExamSystem.Data.UnitOfWork;

    [HandleError]
    public class BaseController : Controller
    {
        public BaseController(ITelerikExamSystemData data)
        {
            this.Data = data;
        }

        protected ITelerikExamSystemData Data { get; private set; }

        protected User CurrentUser { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.CurrentUser = this.Data.Users.All()
                                   .Where(u => u.UserName == requestContext.HttpContext.User.Identity.Name)
                                   .FirstOrDefault();

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}