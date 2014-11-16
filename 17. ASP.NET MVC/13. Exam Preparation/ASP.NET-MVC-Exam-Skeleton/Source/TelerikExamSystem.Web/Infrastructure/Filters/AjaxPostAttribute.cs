namespace TelerikExamSystem.Web.Infrastructure.Filters
{
    using System.Reflection;
    using System.Web.Mvc;

    public class AjaxPostAttribute : AjaxOnlyAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            return base.IsValidForRequest(controllerContext, methodInfo) &&
                   controllerContext.RequestContext.HttpContext.Request.HttpMethod == "POST";
        }
    }
}