namespace ForumSystem.Services.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using ForumSystem.Models;

    public class ArticleDataModel
    {
        public ArticleDataModel()
        {
            this.Tags = new HashSet<TagDataModel>();
        }

        public static Expression<Func<Article, ArticleDataModel>> FromEntityToModel
        {
            get
            {
                return a => new ArticleDataModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = a.Content,
                    Category = a.Category.Name,
                    DateCreated = a.DateCreated,
                    Tags = a.Tags.AsQueryable().Select(TagDataModel.FromEntityToModel).ToList()
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

        public ICollection<TagDataModel> Tags { get; set; }
    }
}