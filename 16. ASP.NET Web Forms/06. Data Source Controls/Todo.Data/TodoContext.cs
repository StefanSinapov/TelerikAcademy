namespace Todo.Data
{
    using System.Data.Entity;
    
    using Todo.Models;

    public class TodoContext : DbContext
    {
        public TodoContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Todo> Todos { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}