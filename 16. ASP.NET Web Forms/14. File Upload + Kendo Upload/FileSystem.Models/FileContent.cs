namespace FileSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class FileContent
    {
        public FileContent()
        {
            this.Id = Guid.NewGuid();
            this.DateAdded = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }

        public string Content { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
