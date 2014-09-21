namespace BugLogger.WebAPI.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using Models;

    public class BugDataModel
    {

        public static Expression<Func<Bug, BugDataModel>> FromEntityToModel
        {
            get
            {
                return bug => new BugDataModel
                {
                    Id = bug.Id,
                    Description = bug.Description,
                    LogDate = bug.LogDate,
                    Status = bug.Status
                };
            }
        }

        public static Expression<Func<BugDataModel, Bug>> FromModelToEntity
        {
            get
            {
                return bug => new Bug
                {
                    Id = bug.Id,
                    Description = bug.Description,
                    LogDate = bug.LogDate,
                    Status = bug.Status
                };
            }
        }

        public BugDataModel()
        {
            
        }

        public BugDataModel(Bug bug)
        {
            this.Id = bug.Id;
            this.Description = bug.Description;
            this.LogDate = bug.LogDate;
            this.Status = bug.Status;
        }

        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime LogDate { get; set; }

        public BugStatus Status { get; set; } 
    }
}