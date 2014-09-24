namespace ForumSystem.WCF
{
    using System;
    using System.Linq;
    using Data;
    using Data.Contracts;
    using DataModels;

    public class AlertsService : IAlertsService
    {
        private readonly IForumSystemAlertsData alertsData = new ForumSystemAlertsData(new ForumSystemDbContext());

        public IQueryable<AlertDataModel> GetAlerts()
        {
            return this.alertsData.Alerts
                       .All()
                       .Where(a => a.ExpirationDate > DateTime.Now)
                       .OrderBy(a => a.ExpirationDate)
                       .Select(AlertDataModel.FromEntityToModel);
        }
    }
}
