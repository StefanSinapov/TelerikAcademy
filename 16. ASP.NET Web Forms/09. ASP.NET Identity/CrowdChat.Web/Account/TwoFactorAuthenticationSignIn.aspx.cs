// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TwoFactorAuthenticationSignIn.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The two factor authentication sign in.
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
    /// The two factor authentication sign in.
    /// </summary>
    public partial class TwoFactorAuthenticationSignIn : Page
    {
        #region Fields

        /// <summary>
        /// The manager.
        /// </summary>
        private readonly UserManager manager;

        /// <summary>
        /// The signin manager.
        /// </summary>
        private readonly ApplicationSignInManager signinManager;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TwoFactorAuthenticationSignIn"/> class.
        /// </summary>
        public TwoFactorAuthenticationSignIn()
        {
            this.manager = this.Context.GetOwinContext().GetUserManager<UserManager>();
            this.signinManager = this.Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// The code submit_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void CodeSubmit_Click(object sender, EventArgs e)
        {
            bool rememberMe = false;
            bool.TryParse(this.Request.QueryString["RememberMe"], out rememberMe);

            SignInStatus result = this.signinManager.TwoFactorSignIn(
                this.SelectedProvider.Value, 
                this.Code.Text, 
                rememberMe, 
                this.RememberBrowser.Checked);
            switch (result)
            {
                case SignInStatus.Success:
                    IdentityHelper.RedirectToReturnUrl(this.Request.QueryString["ReturnUrl"], this.Response);
                    break;
                case SignInStatus.LockedOut:
                    this.Response.Redirect("/Account/Lockout");
                    break;
                case SignInStatus.Failure:
                default:
                    this.FailureText.Text = "Invalid code";
                    this.ErrorMessage.Visible = true;
                    break;
            }
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
            string userId = this.signinManager.GetVerifiedUserId();
            if (userId == null)
            {
                this.Response.Redirect("/Account/Error", true);
            }

            IList<string> userFactors = this.manager.GetValidTwoFactorProviders(userId);
            this.Providers.DataSource = userFactors.Select(x => x).ToList();
            this.Providers.DataBind();
        }

        /// <summary>
        /// The provider submit_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void ProviderSubmit_Click(object sender, EventArgs e)
        {
            if (!this.signinManager.SendTwoFactorCode(this.Providers.SelectedValue))
            {
                this.Response.Redirect("/Account/Error");
            }

            User user = this.manager.FindById(this.signinManager.GetVerifiedUserId());
            if (user != null)
            {
                string code = this.manager.GenerateTwoFactorToken(user.Id, this.Providers.SelectedValue);
            }

            this.SelectedProvider.Value = this.Providers.SelectedValue;
            this.sendcode.Visible = false;
            this.verifycode.Visible = true;
        }

        #endregion
    }
}