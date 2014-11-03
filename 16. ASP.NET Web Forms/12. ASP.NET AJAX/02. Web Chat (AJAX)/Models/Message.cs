namespace WebChat.Models
{
    using System;

    public class Message
    {
        public Message()
        {
            this.DatePublished = DateTime.Now;
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public string Username { get; set; }
        /* public string UserId { get; set; }

         public virtual User User { get; set; }*/

        public DateTime DatePublished { get; set; }
    }
}