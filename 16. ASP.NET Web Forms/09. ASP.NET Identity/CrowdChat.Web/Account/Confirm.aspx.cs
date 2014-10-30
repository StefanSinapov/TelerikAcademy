﻿namespace CrowdChat.Web.Account
{
    using System;
    using System.Web;
    using System.Web.UI;

    using CrowdChat.Web.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    public partial class Confirm : Page
    {
        public Confirm(string statusMessage)
        {
            this.StatusMessage = statusMessage;
        }

        #region Properties

        protected string StatusMessage { get; private set; }

        #endregion

        #region Methods
        protected void Page_Load(object sender, EventArgs e)
        {
            string code = IdentityHelper.GetCodeFromRequest(this.Request);
            string userId = IdentityHelper.GetUserIdFromRequest(this.Request);
            if (code != null && userId != null)
            {
                var manager = this.Context.GetOwinContext().GetUserManager<UserManager>();
                IdentityResult result = manager.ConfirmEmail(userId, code);
                if (result.Succeeded)
                {
                    this.successPanel.Visible = true;
                    return;
                }
            }

            this.successPanel.Visible = false;
            this.errorPanel.Visible = true;
        }

        #endregion
    }
}