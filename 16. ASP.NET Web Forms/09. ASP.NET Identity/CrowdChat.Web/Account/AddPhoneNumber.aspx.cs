// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddPhoneNumber.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The add phone number.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CrowdChat.Web.Account
{
    using System;
    using System.Web;
    using System.Web.UI;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    /// <summary>
    /// The add phone number.
    /// </summary>
    public partial class AddPhoneNumber : Page
    {
        #region Methods

        /// <summary>
        /// The phone number_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void PhoneNumber_Click(object sender, EventArgs e)
        {
            var manager = this.Context.GetOwinContext().GetUserManager<UserManager>();
            string code = manager.GenerateChangePhoneNumberToken(this.User.Identity.GetUserId(), this.PhoneNumber.Text);
            if (manager.SmsService != null)
            {
                var message = new IdentityMessage
                                  {
                                      Destination = this.PhoneNumber.Text, 
                                      Body = "Your security code is " + code
                                  };

                manager.SmsService.Send(message);
            }

            this.Response.Redirect(
                "/Account/VerifyPhoneNumber?PhoneNumber=" + HttpUtility.UrlEncode(this.PhoneNumber.Text));
        }

        #endregion
    }
}