namespace ForumSystem.WCF
{
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using DataModels;

    [ServiceContract]
    public interface IAlertsService
    {
        [OperationContract]
        [WebGet(UriTemplate = "api/Alerts")]
        IQueryable<AlertDataModel> GetAlerts();
    }
}
