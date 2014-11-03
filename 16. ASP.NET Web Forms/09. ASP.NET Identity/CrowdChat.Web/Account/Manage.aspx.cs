namespace CrowdChat.Web.Account
{
    using System;
    using System.Web;
    using System.Web.UI;

    using CrowdChat.Models;
    using CrowdChat.Web.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;

    /// <summary>
    /// The manage.
    /// </summary>
    public partial class Manage : Page
    {
        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether has phone number.
        /// </summary>
        public bool HasPhoneNumber { get; private set; }

        /// <summary>
        /// Gets or sets the logins count.
        /// </summary>
        public int LoginsCount { get; set; }

        /// <summary>
        /// Gets a value indicating whether two factor browser remembered.
        /// </summary>
        public bool TwoFactorBrowserRemembered { get; private set; }

        /// <summary>
        /// Gets a value indicating whether two factor enabled.
        /// </summary>
        public bool TwoFactorEnabled { get; private set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the success message.
        /// </summary>
        protected string SuccessMessage { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// The page_ load.
        /// </summary>
        protected void Page_Load()
        {
            var manager = this.Context.GetOwinContext().GetUserManager<UserManager>();

            this.HasPhoneNumber = string.IsNullOrEmpty(manager.GetPhoneNumber(this.User.Identity.GetUserId()));

            // Enable this after setting up two-factor authentientication
            // PhoneNumber.Text = manager.GetPhoneNumber(User.Identity.GetUserId()) ?? String.Empty;
            this.TwoFactorEnabled = manager.GetTwoFactorEnabled(this.User.Identity.GetUserId());

            this.LoginsCount = manager.GetLogins(this.User.Identity.GetUserId()).Count;

            IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            if (!this.IsPostBack)
            {
                // Determine the sections to render
                if (this.HasPassword(manager))
                {
                    this.ChangePassword.Visible = true;
                }
                else
                {
                    this.CreatePassword.Visible = true;
                    this.ChangePassword.Visible = false;
                }

                // Render success message
                string message = this.Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    this.Form.Action = this.ResolveUrl("~/Account/Manage");

                    this.SuccessMessage = message == "ChangePwdSuccess"
                                              ? "Your password has been changed."
                                              : message == "SetPwdSuccess"
                                                    ? "Your password has been set."
                                                    : message == "RemoveLoginSuccess"
                                                          ? "The account was removed."
                                                          : message == "AddPhoneNumberSuccess"
                                                                ? "Phone number has been added"
                                                                : message == "RemovePhoneNumberSuccess"
                                                                      ? "Phone number was removed"
                                                                      : string.Empty;
                    this.successMessage.Visible = !string.IsNullOrEmpty(this.SuccessMessage);
                }
            }
        }

        protected void RemovePhone_Click(object sender, EventArgs e)
        {
            var manager = this.Context.GetOwinContext().GetUserManager<UserManager>();
            IdentityResult result = manager.SetPhoneNumber(this.User.Identity.GetUserId(), null);
            if (!result.Succeeded)
            {
                return;
            }

            User user = manager.FindById(this.User.Identity.GetUserId());
            if (user != null)
            {
                IdentityHelper.SignIn(manager, user, false);
                this.Response.Redirect("/Account/Manage?m=RemovePhoneNumberSuccess");
            }
        }

        // DisableTwoFactorAuthentication
        /// <summary>
        /// The two factor disable_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void TwoFactorDisable_Click(object sender, EventArgs e)
        {
            var manager = this.Context.GetOwinContext().GetUserManager<UserManager>();
            manager.SetTwoFactorEnabled(this.User.Identity.GetUserId(), false);

            this.Response.Redirect("/Account/Manage");
        }

        protected void TwoFactorEnable_Click(object sender, EventArgs e)
        {
            var manager = this.Context.GetOwinContext().GetUserManager<UserManager>();
            manager.SetTwoFactorEnabled(this.User.Identity.GetUserId(), true);

            this.Response.Redirect("/Account/Manage");
        }

        /// <summary>
        /// The add errors.
        /// </summary>
        /// <param name="result">
        /// The result.
        /// </param>
        private void AddErrors(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                this.ModelState.AddModelError(string.Empty, error);
            }
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