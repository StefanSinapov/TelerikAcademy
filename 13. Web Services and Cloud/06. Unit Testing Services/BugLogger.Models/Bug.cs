namespace BugLogger.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Bug
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public BugStatus Status { get; set; }

        [Required]
        public DateTime LogDate { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}]: {1} - {2}", this.LogDate.ToString("G"),
                this.Description,
                this.Status);
        }
    }
}