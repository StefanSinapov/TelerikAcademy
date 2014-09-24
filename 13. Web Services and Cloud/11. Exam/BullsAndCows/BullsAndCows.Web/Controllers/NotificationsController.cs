namespace BullsAndCows.Web.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Results;
    using System.Web.UI;
    using Antlr.Runtime.Misc;
    using BullsAndCows.Models.Enums;
    using Data;
    using Data.Contracts;
    using DataModels;

    public class NotificationsController : BaseApiController
    {
        private const int DefaultPageSize = 10;

        public NotificationsController()
            : this(new BullsAndCowsData(new BullsAndCowsDbContext()))
        {
        }

        public NotificationsController(IBullsAndCowsData data)
            : base(data)
        {
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult Get()
        {
            return this.Get(0);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult Get(int page)
        {
            var userId = this.GetUserId();

            var notificationsEntities = this.Data.Users.Find(userId).Notifications
                .OrderByDescending(n => n.DateCreated)
                .Skip(page*DefaultPageSize)
                .Take(DefaultPageSize).ToArray();

            var models = notificationsEntities.AsQueryable()
                .Select(NotificationDataModel.FromEntityToModel).ToArray();

            foreach (var notificationsEntity in notificationsEntities)
            {
                notificationsEntity.State = NotificationState.Read;
            }

            this.Data.SaveChanges();

            return Ok(models);
        }

        [HttpGet]
        [Authorize]
        [Route("api/Notifications/Next")]
        public IHttpActionResult Next()
        {
            var userId = this.GetUserId();

            var notification = this.Data.Users.Find(userId).Notifications
                .Where(n => n.State == NotificationState.Unread)
                .OrderBy(n => n.DateCreated)
                .FirstOrDefault();

            if (notification == null)
            {
                //TODO: edit to code 304
                throw new HttpResponseException(HttpStatusCode.NotModified);
            }

            var model = new NotificationDataModel
            {
                DateCreated = notification.DateCreated,
                GameId = notification.GameId,
                Id = notification.Id,
                Message = notification.Message,
                State = notification.State.ToString(),
                Type = notification.Type.ToString()
            };

            notification.State = NotificationState.Read;
            this.Data.SaveChanges();

            return Ok(model);
        }
    }
}