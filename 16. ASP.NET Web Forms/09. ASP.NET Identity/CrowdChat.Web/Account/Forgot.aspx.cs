// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Forgot.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The forgot password.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CrowdChat.Web.Account
{
    using System;
    using System.Web;
    using System.Web.UI;

    using CrowdChat.Models;
    using CrowdChat.Web.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    /// <summary>
    /// The forgot password.
    /// </summary>
    public partial class ForgotPassword : Page
    {
        #region Methods

        /// <summary>
        /// The forgot.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Forgot(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                // Validate the user's email address
                var manager = this.Context.GetOwinContext().GetUserManager<UserManager>();
                User user = manager.FindByName(this.Email.Text);
                if (user == null || !manager.IsEmailConfirmed(user.Id))
                {
                    this.FailureText.Text = "The user either does not exist or is not confirmed.";
                    this.ErrorMessage.Visible = true;
                    return;
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send email with the code and the redirect to reset password page
                // string code = manager.GeneratePasswordResetToken(user.Id);
                // string callbackUrl = IdentityHelper.GetResetPasswordRedirectUrl(code, Request);
                // manager.SendEmail(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>.");
                this.loginForm.Visible = false;
                this.DisplayEmail.Visible = true;
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
        }

        #endregion
    }
}