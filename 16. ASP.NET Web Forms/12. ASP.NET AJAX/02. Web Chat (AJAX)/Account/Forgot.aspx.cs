namespace WebChat.Account
{
    using System;
    using System.Web;
    using System.Web.UI;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    using WebChat.Models;

    public partial class ForgotPassword : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Forgot(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                // Validate the user's email address
                var manager = this.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                User user = manager.FindByName(this.Email.Text);
                if (user == null || !manager.IsEmailConfirmed(user.Id))
                {
                    this.FailureText.Text = "The user either does not exist or is not confirmed.";
                    this.ErrorMessage.Visible = true;
                    return;
                }
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send email with the code and the redirect to reset password page
                //string code = manager.GeneratePasswordResetToken(user.Id);
                //string callbackUrl = IdentityHelper.GetResetPasswordRedirectUrl(code, Request);
                //manager.SendEmail(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>.");
                this.loginForm.Visible = false;
                this.DisplayEmail.Visible = true;
            }
        }
    }
}