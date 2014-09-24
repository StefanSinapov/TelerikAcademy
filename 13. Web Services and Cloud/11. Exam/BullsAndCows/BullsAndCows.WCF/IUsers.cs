namespace BullsAndCows.WCF
{
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using DataModels;

    [ServiceContract(Namespace = "/services/users.svc")]
    public interface IUsers
    {
        [OperationContract]
        [WebGet(UriTemplate = "?page={page}")]
        IQueryable<UserDataModel> Get(int page);

        [OperationContract]
        [WebGet(UriTemplate = "/{id}")]
        UserInfoDataModel GetById(string id);
    }
}
