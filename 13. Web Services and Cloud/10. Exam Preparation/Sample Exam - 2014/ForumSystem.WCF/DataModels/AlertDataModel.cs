namespace ForumSystem.WCF.DataModels
{
    using System;
    using System.Linq.Expressions;
    using Microsoft.Build.Framework;
    using Models;

    public class AlertDataModel
    {
        public static Expression<Func<Alert, AlertDataModel>> FromEntityToModel
        {
            get
            {
                return alert => new AlertDataModel
                {
                    Id = alert.Id,
                    Description = alert.Description,
                    ExpirationDate = alert.ExpirationDate
                };
            }
        }

        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime ExpirationDate { get; set; } 
    }
}