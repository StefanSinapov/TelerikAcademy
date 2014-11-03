namespace CrowdChat.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Message
    {
        public Message()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public string Content { get; set; }

        public User Author { get; set; }

        public string AuthorId { get; set; }

        public DateTime DateCreated { get; set; }
    }
}