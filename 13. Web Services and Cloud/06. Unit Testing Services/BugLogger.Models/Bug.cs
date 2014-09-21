namespace BugLogger.Models
{
    using System;

    public class Bug
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public BugStatus Status { get; set; }

        public DateTime LogDate { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}]: {1} - {2}", this.LogDate.ToString("G"),
                this.Description,
                this.Status);
        }
    }
}