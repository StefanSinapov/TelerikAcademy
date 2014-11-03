namespace WebChat.Account
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    using WebChat.Models;

    public partial class ManageLogins : System.Web.UI.Page
    {
        protected string SuccessMessage
        {
            get;
            private set;
        }
        protected bool CanRemoveExternalLogins
        {
            get;
            private set;
        }

        private bool HasPassword(ApplicationUserManager manager)
        {
            return manager.HasPassword(this.User.Identity.GetUserId());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var manager = this.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            this.CanRemoveExternalLogins = manager.GetLogins(this.User.Identity.GetUserId()).Count() > 1;

            this.SuccessMessage = String.Empty;
            this.successMessage.Visible = !String.IsNullOrEmpty(this.SuccessMessage);
        }

        public IEnumerable<UserLoginInfo> GetLogins()
        {
            var manager = this.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var accounts = manager.GetLogins(this.User.Identity.GetUserId());
            this.CanRemoveExternalLogins = accounts.Count() > 1 || this.HasPassword(manager);
            return accounts;
        }

        public void RemoveLogin(string loginProvider, string providerKey)
        {
            var manager = this.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var result = manager.RemoveLogin(this.User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            string msg = String.Empty;
            if (result.Succeeded)
            {
                var user = manager.FindById(this.User.Identity.GetUserId());
                IdentityHelper.SignIn(manager, user, isPersistent: false);
                msg = "?m=RemoveLoginSuccess";
            }
            this.Response.Redirect("~/Account/ManageLogins" + msg);
        }
    }
}