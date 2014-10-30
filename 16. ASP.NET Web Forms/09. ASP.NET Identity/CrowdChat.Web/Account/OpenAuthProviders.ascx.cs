// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenAuthProviders.ascx.cs" company="">
//   
// </copyright>
// <summary>
//   The open auth providers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CrowdChat.Web.Account
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web;
    using System.Web.UI;

    using CrowdChat.Web.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;

    /// <summary>
    /// The open auth providers.
    /// </summary>
    public partial class OpenAuthProviders : UserControl
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the return url.
        /// </summary>
        public string ReturnUrl { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get provider names.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<string> GetProviderNames()
        {
            return
                this.Context.GetOwinContext()
                    .Authentication.GetExternalAuthenticationTypes()
                    .Select(t => t.AuthenticationType);
        }

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
            if (this.IsPostBack)
            {
                string provider = this.Request.Form["provider"];
                if (provider == null)
                {
                    return;
                }

                // Request a redirect to the external login provider
                string redirectUrl =
                    this.ResolveUrl(
                        string.Format(
                            CultureInfo.InvariantCulture, 
                            "~/Account/RegisterExternalLogin?{0}={1}&returnUrl={2}", 
                            IdentityHelper.ProviderNameKey, 
                            provider, 
                            this.ReturnUrl));
                var properties = new AuthenticationProperties { RedirectUri = redirectUrl };

                // Add xsrf verification when linking accounts
                if (this.Context.User.Identity.IsAuthenticated)
                {
                    properties.Dictionary[IdentityHelper.XsrfKey] = this.Context.User.Identity.GetUserId();
                }

                this.Context.GetOwinContext().Authentication.Challenge(properties, provider);
                this.Response.StatusCode = 401;
                this.Response.End();
            }
        }

        #endregion
    }
}