namespace MusicStore.WebAPI.Controllers
{
    using System.Web.Http;

    using Data.Contracts;

    public class BaseApiController : ApiController
    {
        protected IMusicStoreData Data;

        protected BaseApiController(IMusicStoreData data)
        {
            this.Data = data;
        }
    }
}
