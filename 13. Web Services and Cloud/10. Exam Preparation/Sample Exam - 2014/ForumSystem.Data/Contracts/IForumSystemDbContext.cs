namespace ForumSystem.Data.Contracts
{
    using System.Data.Entity;
    using Models;

    public interface IForumSystemDbContext //: IDbContext
    {
        IDbSet<Alert> Alerts { get; set; }

        IDbSet<Article> Articles { get; set; }
        
        IDbSet<Category> Categories { get; set; }
        
        IDbSet<Comment> Comments { get; set; }
        
        IDbSet<Like> Likes { get; set; }
        
        IDbSet<Tag> Tags { get; set; }

        int SaveChanges();
    }
}