namespace LaptopSystem.Web.Areas.Admin.Controllers.Base
{
    using System.Web.Mvc;

    using LaptopSystem.Common;
    using LaptopSystem.Data.UnitOfWork;
    using LaptopSystem.Web.Controllers.Base;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public abstract class AdminController : BaseController
    {
        protected AdminController(ILaptopSystemData data)
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