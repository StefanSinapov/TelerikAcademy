// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="">
//   
// </copyright>
// <summary>
//   The route config.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CrowdChat.Web
{
    using System.Web.Routing;

    using Microsoft.AspNet.FriendlyUrls;

    /// <summary>
    /// The route config.
    /// </summary>
    public static class RouteConfig
    {
        #region Public Methods and Operators

        /// <summary>
        /// The register routes.
        /// </summary>
        /// <param name="routes">
        /// The routes.
        /// </param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
        }

        #endregion
    }
}