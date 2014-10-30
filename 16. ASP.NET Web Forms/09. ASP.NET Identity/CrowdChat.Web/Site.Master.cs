// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Site.Master.cs" company="">
//   
// </copyright>
// <summary>
//   The site master.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CrowdChat.Web
{
    using System;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    /// <summary>
    /// The site master.
    /// </summary>
    public partial class SiteMaster : MasterPage
    {
        #region Constants

        /// <summary>
        /// The anti xsrf token key.
        /// </summary>
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";

        /// <summary>
        /// The anti xsrf user name key.
        /// </summary>
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";

        #endregion

        #region Fields

        /// <summary>
        /// The _anti xsrf token value.
        /// </summary>
        private string _antiXsrfTokenValue;

        #endregion

        #region Methods

        /// <summary>
        /// The page_ init.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            HttpCookie requestCookie = this.Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                this._antiXsrfTokenValue = requestCookie.Value;
                this.Page.ViewStateUserKey = this._antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                this._antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                this.Page.ViewStateUserKey = this._antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                                         {
                                             HttpOnly = true, 
                                             Value = this._antiXsrfTokenValue
                                         };
                if (FormsAuthentication.RequireSSL && this.Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }

                this.Response.Cookies.Set(responseCookie);
            }

            this.Page.PreLoad += this.master_Page_PreLoad;
        }

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
        }

        /// <summary>
        /// The unnamed_ logging out.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            this.Context.GetOwinContext().Authentication.SignOut();
        }

        /// <summary>
        /// The master_ page_ pre load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// </exception>
        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                // Set Anti-XSRF token
                this.ViewState[AntiXsrfTokenKey] = this.Page.ViewStateUserKey;
                this.ViewState[AntiXsrfUserNameKey] = this.Context.User.Identity.Name ?? string.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)this.ViewState[AntiXsrfTokenKey] != this._antiXsrfTokenValue
                    || (string)this.ViewState[AntiXsrfUserNameKey] != (this.Context.User.Identity.Name ?? string.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        #endregion
    }
}