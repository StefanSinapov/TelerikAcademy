namespace ForumSystem.Services.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using ForumSystem.Models;

    public class ArticleByTagsDataModel
    {
        public static Expression<Func<Article, ArticleByTagsDataModel>> FromEntityToModel
        {
            get
            {
                return a => new ArticleByTagsDataModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = a.Content,
                    Category = a.Category.Name,
                    DateCreated = a.DateCreated
                };
            }
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
    }
}