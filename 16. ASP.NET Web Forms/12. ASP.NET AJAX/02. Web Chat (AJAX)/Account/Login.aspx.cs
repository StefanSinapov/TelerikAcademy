namespace WebChat.Account
{
    using System;
    using System.Web;
    using System.Web.UI;

    using Microsoft.AspNet.Identity.Owin;

    using WebChat.Models;

    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            this.OpenAuthLogin.ReturnUrl = this.Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(this.Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                this.RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                // Validate the user password
                var manager = this.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = this.Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                // This doen't count login failures towards account lockout
                // To enable password failures to trigger lockout, change to shouldLockout: true
                var result = signinManager.PasswordSignIn(this.Email.Text, this.Password.Text, this.RememberMe.Checked, shouldLockout: false);

                switch (result)
                {
                    case SignInStatus.Success:
                        IdentityHelper.RedirectToReturnUrl(this.Request.QueryString["ReturnUrl"], this.Response);
                        break;
                    case SignInStatus.LockedOut:
                        this.Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        this.Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", 
                                                        this.Request.QueryString["ReturnUrl"],
                                                        this.RememberMe.Checked),
                                          true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        this.FailureText.Text = "Invalid login attempt";
                        this.ErrorMessage.Visible = true;
                        break;
                }
            }
        }
    }
}