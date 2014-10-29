namespace Articles.Web.Account
{
    using System;
    using System.Web;

    using Articles.Web.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    public partial class VerifyPhoneNumber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var manager = this.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var phonenumber = this.Request.QueryString["PhoneNumber"];
            var code = manager.GenerateChangePhoneNumberToken(this.User.Identity.GetUserId(), phonenumber);           
            this.PhoneNumber.Value = phonenumber;
        }

        protected void Code_Click(object sender, EventArgs e)
        {
            if (!this.ModelState.IsValid)
            {
                this.ModelState.AddModelError("", "Invalid code");
                return;
            }

            var manager = this.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var result = manager.ChangePhoneNumber(this.User.Identity.GetUserId(), this.PhoneNumber.Value, this.Code.Text);

            if (result.Succeeded)
            {
                var user = manager.FindById(this.User.Identity.GetUserId());

                if (user != null)
                {
                    IdentityHelper.SignIn(manager, user, false);
                    this.Response.Redirect("/Account/Manage?m=AddPhoneNumberSuccess");
                }
            }

            // If we got this far, something failed, redisplay form
            this.ModelState.AddModelError("", "Failed to verify phone");
        }
    }
}