// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VerifyPhoneNumber.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The verify phone number.
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
    /// The verify phone number.
    /// </summary>
    public partial class VerifyPhoneNumber : Page
    {
        #region Methods

        /// <summary>
        /// The code_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Code_Click(object sender, EventArgs e)
        {
            if (!this.ModelState.IsValid)
            {
                this.ModelState.AddModelError(string.Empty, "Invalid code");
                return;
            }

            var manager = this.Context.GetOwinContext().GetUserManager<UserManager>();

            IdentityResult result = manager.ChangePhoneNumber(
                this.User.Identity.GetUserId(), 
                this.PhoneNumber.Value, 
                this.Code.Text);

            if (result.Succeeded)
            {
                User user = manager.FindById(this.User.Identity.GetUserId());

                if (user != null)
                {
                    IdentityHelper.SignIn(manager, user, false);
                    this.Response.Redirect("/Account/Manage?m=AddPhoneNumberSuccess");
                }
            }

            // If we got this far, something failed, redisplay form
            this.ModelState.AddModelError(string.Empty, "Failed to verify phone");
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
            string phonenumber = this.Request.QueryString["PhoneNumber"];
            string code = manager.GenerateChangePhoneNumberToken(this.User.Identity.GetUserId(), phonenumber);
            this.PhoneNumber.Value = phonenumber;
        }

        #endregion
    }
}