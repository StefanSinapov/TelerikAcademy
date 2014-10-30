// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResetPassword.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The reset password.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CrowdChat.Web.Account
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.UI;

    using CrowdChat.Models;
    using CrowdChat.Web.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    /// <summary>
    /// The reset password.
    /// </summary>
    public partial class ResetPassword : Page
    {
        #region Properties

        /// <summary>
        /// Gets the status message.
        /// </summary>
        protected string StatusMessage { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// The reset_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Reset_Click(object sender, EventArgs e)
        {
            string code = IdentityHelper.GetCodeFromRequest(this.Request);
            if (code != null)
            {
                var manager = this.Context.GetOwinContext().GetUserManager<UserManager>();

                User user = manager.FindByName(this.Email.Text);
                if (user == null)
                {
                    this.ErrorMessage.Text = "No user found";
                    return;
                }

                IdentityResult result = manager.ResetPassword(user.Id, code, this.Password.Text);
                if (result.Succeeded)
                {
                    this.Response.Redirect("~/Account/ResetPasswordConfirmation");
                    return;
                }

                this.ErrorMessage.Text = result.Errors.FirstOrDefault();
                return;
            }

            this.ErrorMessage.Text = "An error has occurred";
        }

        #endregion
    }
}