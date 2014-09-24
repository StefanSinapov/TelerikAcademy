namespace ForumSystem.Services.DataModels
{
    using System;
    using System.Linq.Expressions;
    using ForumSystem.Models;

    public class LikeDataModel
    {
        public static Expression<Func<Like, LikeDataModel>> FromEntityToModel
        {
            get
            {
                return like => new LikeDataModel
                {
                    Id = like.Id,
                    DateCreated = like.DateCreated,
                    AuthorName = like.User.UserName
                };
            }
        }

        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string AuthorName { get; set; }
    }
}