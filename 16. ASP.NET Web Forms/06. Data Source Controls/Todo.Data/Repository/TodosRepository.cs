namespace Todo.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Todo.Data.DataModels;
    using Todo.Models;

    public class TodosRepository
    {
        private readonly TodoContext context;

        public TodosRepository()
            : this(new TodoContext())
        {
        }

        public TodosRepository(TodoContext context)
        {
            this.context = context;
        }

        public ICollection<TodoModel> SelectTodos()
        {
            var items = this.context.Todos.Select(
                t => new TodoModel
                         {
                             Id = t.Id,
                             Title = t.Title,
                             Category = t.Category.Name,
                             LastModified = t.LastModified,
                             Content = t.Content
                         }).ToList();

            return items;
        }

        public void InsertTodo(string Title, string Content, string LastModified, string Category)
        {
            var cat = this.context.Categories.FirstOrDefault(x => x.Name == Category)
                      ?? new Category { Name = Category };

            var newTodo = new Todo
            {
                Title = Title,
                Content = Content,
                LastModified = DateTime.Now,
                Category = cat
            };

            this.context.Todos.Add(newTodo);
            this.context.SaveChanges();
        }

        public void EditTodo(int Id, string Title, string Content, string LastModified, string Category)
        {
            var found = this.context.Todos.FirstOrDefault(x => x.Id == Id);

            if (found == null)
            {
                return;
            }

            found.Title = Title;
            found.Content = Content;
            found.LastModified = DateTime.Now;

            var cat = this.context.Categories.First(x => x.Name == Category)
                ?? new Category { Name = Category };

            found.Category = cat;

            this.context.SaveChanges();
        }

        public void DeleteTodo(int Id)
        {
            var found = this.context.Todos.FirstOrDefault(x => x.Id == Id);

            if (found != null)
            {
                this.context.Todos.Remove(found);
                this.context.SaveChanges();
            }
            else
            {
                return;
            }
        }
    }
}