namespace TelerikExamSystem.Web.Areas.Admin.Controllers.Base
{
    using System.Web.Mvc;

    using TelerikExamSystem.Common;
    using TelerikExamSystem.Data.UnitOfWork;
    using TelerikExamSystem.Web.Controllers.Base;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public abstract class AdminController : BaseController
    {
        protected AdminController(ITelerikExamSystemData data)
            : base(data)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Data.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}