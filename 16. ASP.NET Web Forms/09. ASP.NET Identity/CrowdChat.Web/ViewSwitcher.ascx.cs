// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewSwitcher.ascx.cs" company="">
//   
// </copyright>
// <summary>
//   The view switcher.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CrowdChat.Web
{
    using System;
    using System.Web;
    using System.Web.Routing;
    using System.Web.UI;

    using Microsoft.AspNet.FriendlyUrls.Resolvers;

    /// <summary>
    /// The view switcher.
    /// </summary>
    public partial class ViewSwitcher : UserControl
    {
        #region Properties

        /// <summary>
        /// Gets the alternate view.
        /// </summary>
        protected string AlternateView { get; private set; }

        /// <summary>
        /// Gets the current view.
        /// </summary>
        protected string CurrentView { get; private set; }

        /// <summary>
        /// Gets the switch url.
        /// </summary>
        protected string SwitchUrl { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// The page_ load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Determine current view
            bool isMobile = WebFormsFriendlyUrlResolver.IsMobileView(new HttpContextWrapper(this.Context));
            this.CurrentView = isMobile ? "Mobile" : "Desktop";

            // Determine alternate view
            this.AlternateView = isMobile ? "Desktop" : "Mobile";

            // Create switch URL from the route, e.g. ~/__FriendlyUrls_SwitchView/Mobile?ReturnUrl=/Page
            string switchViewRouteName = "AspNet.FriendlyUrls.SwitchView";
            RouteBase switchViewRoute = RouteTable.Routes[switchViewRouteName];
            if (switchViewRoute == null)
            {
                // Friendly URLs is not enabled or the name of the switch view route is out of sync
                this.Visible = false;
                return;
            }

            string url = this.GetRouteUrl(
                switchViewRouteName, 
                new { view = this.AlternateView, __FriendlyUrls_SwitchViews = true });
            url += "?ReturnUrl=" + HttpUtility.UrlEncode(this.Request.RawUrl);
            this.SwitchUrl = url;
        }

        #endregion
    }
}