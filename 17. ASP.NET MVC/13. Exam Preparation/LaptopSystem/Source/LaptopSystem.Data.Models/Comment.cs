namespace LaptopSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int LaptopId { get; set; }

        public virtual Laptop Laptop { get; set; }
    }
}