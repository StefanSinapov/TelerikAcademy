namespace Todo.Data.Repository
{
    using System.Collections.Generic;
    using System.Linq;

    using Todo.Data;
    using Todo.Models;

    public class CategoriesRepository
    {
        private readonly TodoContext context;

        public CategoriesRepository()
            : this(new TodoContext())
        {
        }

        public CategoriesRepository(TodoContext context)
        {
            this.context = context;
        }

        public List<Category> SelectCategories()
        {
            var categories = this.context.Categories.ToList();

            return categories;
        }

        public void InsertCategory(int Id, string Name)
        {
            var newCategory = new Category { Name = Name };

            this.context.Categories.Add(newCategory);
            this.context.SaveChanges();
        }

        public void EditCategories(int Id, string Name)
        {
            var found = this.context.Categories.First(x => x.Id == Id);

            found.Name = Name;
            this.context.SaveChanges();
        }

        public void DeleteCategories(int Id)
        {
            var found = this.context.Categories.Include("Todos").First(x => x.Id == Id);
            this.context.Todos.RemoveRange(found.Todos);
            this.context.Categories.Remove(found);
            this.context.SaveChanges();
        }
    }
}