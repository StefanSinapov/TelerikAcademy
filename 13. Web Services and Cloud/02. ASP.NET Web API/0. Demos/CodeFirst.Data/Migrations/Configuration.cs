namespace CodeFirst.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    using CodeFirst.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ForumDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        // This method will be called after migrating to the latest version.
        protected override void Seed(ForumDbContext context)
        {
            context.Tags.AddOrUpdate(new Tag { Text = "срок" });
            context.Tags.AddOrUpdate(new Tag { Text = "форум" });

            var category = new Category { Name = "Category" };
            context.Categories.AddOrUpdate(x => x.Name, category);
            context.Posts.AddOrUpdate(
                x => x.Title,
                new Post { CategoryId = category.CategoryId, Content = "Content", CreatedOn = DateTime.Now, Title = "Title" });
            context.Posts.AddOrUpdate(
                x => x.Title,
                new Post { CategoryId = category.CategoryId, Content = "Content 2", CreatedOn = DateTime.Now, Title = "Title 2" });
            context.Posts.AddOrUpdate(
                x => x.Title,
                new Post { CategoryId = category.CategoryId, Content = "Content 3", CreatedOn = DateTime.Now, Title = "Title 3" });
        }
    }
}