namespace ForumSystem.Models
{
    using System;

    public class Alert
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}