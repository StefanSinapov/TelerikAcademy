namespace BugLogger.WebAPI.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Models;

    public class CreateBugModel
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime LogDate { get; set; }

        public BugStatus Status { get; set; }  
    }
}