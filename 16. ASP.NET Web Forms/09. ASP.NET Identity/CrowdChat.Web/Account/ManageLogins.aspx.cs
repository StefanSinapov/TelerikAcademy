// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManageLogins.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The manage logins.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CrowdChat.Web.Account
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;

    using CrowdChat.Models;
    using CrowdChat.Web.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    /// <summary>
    /// The manage logins.
    /// </summary>
    public partial class ManageLogins : Page
    {
        #region Properties

        /// <summary>
        /// Gets a value indicating whether can remove external logins.
        /// </summary>
        protected bool CanRemoveExternalLogins { get; private set; }

        /// <summary>
        /// Gets the success message.
        /// </summary>
        protected string SuccessMessage { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get logins.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<UserLoginInfo> GetLogins()
        {
            var manager = this.Context.GetOwinContext().GetUserManager<UserManager>();
            IList<UserLoginInfo> accounts = manager.GetLogins(this.User.Identity.GetUserId());
            this.CanRemoveExternalLogins = accounts.Count() > 1 || this.HasPassword(manager);
            return accounts;
        }

        /// <summary>
        /// The remove login.
        /// </summary>
        /// <param name="loginProvider">
        /// The login provider.
        /// </param>
        /// <param name="providerKey">
        /// The provider key.
        /// </param>
        public void RemoveLogin(string loginProvider, string providerKey)
        {
            var manager = this.Context.GetOwinContext().GetUserManager<UserManager>();
            IdentityResult result = manager.RemoveLogin(
                this.User.Identity.GetUserId(), 
                new UserLoginInfo(loginProvider, providerKey));
            string msg = string.Empty;
            if (result.Succeeded)
            {
                User user = manager.FindById(this.User.Identity.GetUserId());
                IdentityHelper.SignIn(manager, user, false);
                msg = "?m=RemoveLoginSuccess";
            }

            this.Response.Redirect("~/Account/ManageLogins" + msg);
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
            var manager = this.Context.GetOwinContext().GetUserManager<UserManager>();
            this.CanRemoveExternalLogins = manager.GetLogins(this.User.Identity.GetUserId()).Count() > 1;

            this.SuccessMessage = string.Empty;
            this.successMessage.Visible = !string.IsNullOrEmpty(this.SuccessMessage);
        }

        /// <summary>
        /// The has password.
        /// </summary>
        /// <param name="manager">
        /// The manager.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool HasPassword(UserManager manager)
        {
            return manager.HasPassword(this.User.Identity.GetUserId());
        }

        #endregion
    }
}