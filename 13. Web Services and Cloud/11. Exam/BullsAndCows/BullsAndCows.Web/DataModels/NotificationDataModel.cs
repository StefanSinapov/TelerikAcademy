namespace BullsAndCows.Web.DataModels
{
    using System;
    using System.Linq.Expressions;
    using BullsAndCows.Models;

    public class NotificationDataModel
    {
        public static Expression<Func<Notification, NotificationDataModel>> FromEntityToModel
        {
            get
            {
                return n => new NotificationDataModel
                {
                    Id = n.Id,
                    Message = n.Message,
                    DateCreated = n.DateCreated,
                    GameId = n.GameId,
                    State = n.State.ToString(),
                    Type = n.Type.ToString()
                };
            }
        }

        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        public string Type { get; set; }

        public string State { get; set; }

        public int GameId { get; set; }
    }
}