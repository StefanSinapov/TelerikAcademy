namespace ForumSystem.Services.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using ForumSystem.Models;

    public class ArticleDetailsDataModel
    {
        public static Expression<Func<Article, ArticleDetailsDataModel>> FromEntityToModel
        {
            get
            {
                return article => new ArticleDetailsDataModel
                {
                    Id = article.Id,
                    Title = article.Title,
                    Content = article.Content,
                    Category = article.Category.Name,
                    DateCreated = article.DateCreated,
                    Tags = article.Tags.AsQueryable()
                            .Select(TagDataModel.FromEntityToModel).ToList(),
                    Comments = article.Comments.AsQueryable()
                            .Select(CommentDataModel.FromEntityToModel).ToList(),
                    Likes = article.Likes.AsQueryable()
                            .Select(LikeDataModel.FromEntityToModel).ToList(),
                };
            }
        }

        private ArticleDetailsDataModel()
        {
            this.Tags = new HashSet<TagDataModel>();
            this.Comments = new HashSet<CommentDataModel>();
            this.Likes = new HashSet<LikeDataModel>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        public string Content { get; set; }

        [Required]
        public string Category { get; set; }

        public DateTime DateCreated { get; set; }

        public ICollection<TagDataModel> Tags { get; set; }

        public ICollection<CommentDataModel> Comments { get; set; }

        public ICollection<LikeDataModel> Likes { get; set; } 
    }
}