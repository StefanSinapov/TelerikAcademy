namespace ForumSystem.Data.Contracts
{
    using Models;

    public interface IForumSystemData
    {
        IRepository<Article> Articles { get; } 
        
        IRepository<Category> Categories { get; } 
        
        IRepository<Comment> Comments { get; } 
        
        IRepository<Like> Likes { get; } 
        
        IRepository<Tag> Tags { get; } 

        int SaveChanges();
    }
}