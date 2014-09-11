using System.Linq;
using System.Collections.Generic;
using System;

namespace WcfRESTServiceDemo
{
    public class ServiceCategories : IServiceCategories
    {
        public IEnumerable<CategoryDTO> GetAllCategories()
        {
            NorthwindEntities context = new NorthwindEntities();
            var categories = context.Categories.OrderBy(c => c.CategoryID).ToList();
            IEnumerable<CategoryDTO> categoriesDTOs = 
                categories.Select(c => CategoryDTO.CreateFromCategory(c));
            return categoriesDTOs;
        }

        public CategoryDTO FindCategoryByID(string categoryID)
        {
            int categoryIDint = Int32.Parse(categoryID);
            NorthwindEntities context = new NorthwindEntities();
            Category category =
                context.Categories.Where(c => c.CategoryID == categoryIDint).Single();
            CategoryDTO categoryDTO = CategoryDTO.CreateFromCategory(category);
            return categoryDTO;
        }

        public int CreateCategory(CategoryDTO categoryDTO)
        {
            NorthwindEntities context = new NorthwindEntities();
            Category category = categoryDTO.ToCategory();
            context.Categories.AddObject(category);
            context.SaveChanges();
            return category.CategoryID;
        }
    }
}
