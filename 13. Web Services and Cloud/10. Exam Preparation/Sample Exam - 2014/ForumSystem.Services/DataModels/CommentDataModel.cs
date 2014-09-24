namespace ForumSystem.Services.DataModels
{
    using System;
    using System.Linq.Expressions;
    using ForumSystem.Models;

    public class CommentDataModel
    {
        public static Expression<Func<Comment, CommentDataModel>> FromEntityToModel
        {
            get
            {
                return c => new CommentDataModel
                {
                    Id = c.Id,
                    Content = c.Content,
                    DateCreated = c.DateCreated,
                    AuthorName = c.User.UserName
                };
            }
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string AuthorName { get; set; }
    }
}