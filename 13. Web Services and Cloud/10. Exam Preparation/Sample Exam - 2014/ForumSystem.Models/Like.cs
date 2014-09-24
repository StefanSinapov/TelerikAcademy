namespace ForumSystem.Models
{
    using System;

    public class Like
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }

        public DateTime DateCreated { get; set; }
    }
}