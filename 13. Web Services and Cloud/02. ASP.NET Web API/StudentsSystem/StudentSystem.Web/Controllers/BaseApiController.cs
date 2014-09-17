namespace StudentSystem.Web.Controllers
{
    using System.Web.Http;
    using Data.Contracts;

    public abstract class BaseApiController : ApiController
    {
        protected IStudentSystemData Data;

        protected BaseApiController(IStudentSystemData data)
        {
            this.Data = data;
        }
    }
}