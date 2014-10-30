// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManagePassword.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The manage password.
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
    /// The manage password.
    /// </summary>
    public partial class ManagePassword : Page
    {
        #region Properties

        /// <summary>
        /// Gets the success message.
        /// </summary>
        protected string SuccessMessage { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// The change password_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                var manager = this.Context.GetOwinContext().GetUserManager<UserManager>();
                IdentityResult result = manager.ChangePassword(
                    this.User.Identity.GetUserId(), 
                    this.CurrentPassword.Text, 
                    this.NewPassword.Text);
                if (result.Succeeded)
                {
                    User user = manager.FindById(this.User.Identity.GetUserId());
                    IdentityHelper.SignIn(manager, user, false);
                    this.Response.Redirect("~/Account/Manage?m=ChangePwdSuccess");
                }
                else
                {
                    this.AddErrors(result);
                }
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
            var manager = this.Context.GetOwinContext().GetUserManager<UserManager>();

            if (!this.IsPostBack)
            {
                // Determine the sections to render
                if (this.HasPassword(manager))
                {
                    this.changePasswordHolder.Visible = true;
                }
                else
                {
                    this.setPassword.Visible = true;
                    this.changePasswordHolder.Visible = false;
                }

                // Render success message
                string message = this.Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    this.Form.Action = this.ResolveUrl("~/Account/Manage");
                }
            }
        }

        /// <summary>
        /// The set password_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void SetPassword_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                // Create the local login info and link the local account to the user
                var manager = this.Context.GetOwinContext().GetUserManager<UserManager>();
                IdentityResult result = manager.AddPassword(this.User.Identity.GetUserId(), this.password.Text);
                if (result.Succeeded)
                {
                    this.Response.Redirect("~/Account/Manage?m=SetPwdSuccess");
                }
                else
                {
                    this.AddErrors(result);
                }
            }
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