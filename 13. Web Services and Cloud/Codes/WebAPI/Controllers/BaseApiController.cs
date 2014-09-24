namespace Project.Services.Controllers
{
    using System.Web.Http;
    using Data.Contracts;
    using Microsoft.AspNet.Identity;

    public class BaseApiController : ApiController
    {
        public BaseApiController(IProjectData data)
        {
            this.Data = data;
        }

        public IProjectData Data { get; set; }

        protected string GetUserId()
        {
            string userId = this.User.Identity.GetUserId();
            return userId;
        }

        protected string GetUsername()
        {
            string username = this.User.Identity.GetUserName();
            return username;
        }
    }
}