namespace ForumSystem.Services.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using ForumSystem.Models;

    public class CategoryDataModel
    {
        public static Expression<Func<Category, CategoryDataModel>> FromEntityToModel
        {
            get
            {
                return category => new CategoryDataModel
                {
                    Id = category.Id,
                    Name = category.Name
                };
            }
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}