using System.ServiceModel;
using System.Collections.Generic;
using System.ServiceModel.Web;

namespace WcfRESTServiceDemo
{
    [ServiceContract]
    public interface IServiceCategories
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Categories/all")]
        IEnumerable<CategoryDTO> GetAllCategories();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Category/{categoryID}")]
        CategoryDTO FindCategoryByID(string categoryID);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Categories/new")]
        int CreateCategory(CategoryDTO category);
    }
}
