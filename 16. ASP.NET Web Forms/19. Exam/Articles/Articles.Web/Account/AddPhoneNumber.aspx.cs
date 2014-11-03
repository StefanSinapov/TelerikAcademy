namespace Articles.Web.Account
{
    using System;
    using System.Web;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    public partial class AddPhoneNumber : System.Web.UI.Page
    {
        protected void PhoneNumber_Click(object sender, EventArgs e)
        {
            var manager = this.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var code = manager.GenerateChangePhoneNumberToken(this.User.Identity.GetUserId(), this.PhoneNumber.Text);
            if (manager.SmsService != null)
            {
                var message = new IdentityMessage
                {
                    Destination = this.PhoneNumber.Text,
                    Body = "Your security code is " + code
                };

                manager.SmsService.Send(message);
            }

            this.Response.Redirect("/Account/VerifyPhoneNumber?PhoneNumber=" + HttpUtility.UrlEncode(this.PhoneNumber.Text));
        }
    }
}