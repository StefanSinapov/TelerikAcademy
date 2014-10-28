namespace BarterSystem.WebForms.Controls.Notifier
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Enums;

    public class Notifier : UserControl
    {
        private const string KeyNotificationMessages = "Notification";
        private const string KeyShowAfterRedirect =
            "NotificationsShowAfterRedirect";

        public static void AddMessage(Notification msg)
        {
            List<Notification> messages = Notifications ?? new List<Notification>();

            messages.Add(msg);
            HttpContext.Current.Session[KeyNotificationMessages] = messages;
        }

        public static void Success(string msg)
        {
            AddMessage(new Notification
            {
                Text = msg,
                Type = NotificationType.Success,
                AutoHide = true
            });
        }

        public static void Error(string msg)
        {
            AddMessage(new Notification
            {
                Text = msg,
                Type = NotificationType.Danger,
                AutoHide = true
            });
        }

        public static void Warning(string msg)
        {
            AddMessage(new Notification
            {
                Text = msg,
                Type = NotificationType.Warning,
                AutoHide = true
            });
        }

        public static void Info(string msg)
        {
            AddMessage(new Notification
            {
                Text = msg,
                Type = NotificationType.Info,
                AutoHide = true
            });
        }

        public static bool ShowAfterRedirect
        {
            get
            {
                object showAfterRedirect =
                    HttpContext.Current.Session[KeyShowAfterRedirect];
                return showAfterRedirect != null;
            }

            set
            {
                if (value)
                {
                    HttpContext.Current.Session[KeyShowAfterRedirect] = true;
                }
                else
                {
                    HttpContext.Current.Session.Remove(KeyShowAfterRedirect);
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ShowWaitingNotificationMessages();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!ShowAfterRedirect)
            {
                this.ShowWaitingNotificationMessages();
            }
        }

        private static void ClearMessages()
        {
            HttpContext.Current.Session[KeyNotificationMessages] = null;
        }

        private void ShowWaitingNotificationMessages()
        {
            if (Notifications != null)
            {
                int index = 1;
                foreach (var msg in Notifications)
                {
                    var msgPanel = new Panel
                    {
                        CssClass = "pull-right col-xs-4 col-md-4 alert alert-" + msg.Type.ToString().ToLower()
                    };
                    if (msg.AutoHide)
                    {
                        msgPanel.CssClass += " AutoHide";
                    }

                    msgPanel.ID = msg.Type + "Msg" + index;
                    var msgLiteral = new Literal
                    {
                        Mode = LiteralMode.Encode,
                        Text = msg.Text
                    };
                    msgPanel.Controls.Add(msgLiteral);
                    this.Controls.Add(msgPanel);
                    index++;
                }

                ClearMessages();

                this.IncludeCssAndJs();
            }

            ShowAfterRedirect = false;
        }

        private static List<Notification> Notifications
        {
            get
            {
                var messages = (List<Notification>)
                    HttpContext.Current.Session[KeyNotificationMessages];
                return messages;
            }
        }

        private void IncludeCssAndJs()
        {
            ClientScriptManager cs = this.Page.ClientScript;

            // Include the jquery library (if not already included)
            string jqueryScriptUrl = this.TemplateSourceDirectory +
                "/js/jquery-2.1.1.min.js";
            if (!cs.IsStartupScriptRegistered(jqueryScriptUrl))
            {
                cs.RegisterClientScriptInclude(jqueryScriptUrl, jqueryScriptUrl);
            }

            // Include the notifier.js library (if not already included)
            string notifierScriptUrl = this.TemplateSourceDirectory +
                "/Controls/Notifier/js/notifier.js";
            if (!cs.IsStartupScriptRegistered(notifierScriptUrl))
            {
                cs.RegisterClientScriptInclude(notifierScriptUrl, notifierScriptUrl);
            }

            // Include the bootstrap.css stylesheet (if not already included)
         /*   string cssRelativeUrl = this.TemplateSourceDirectory +
                "/css/bootstrap.css";
            if (!cs.IsClientScriptBlockRegistered(cssRelativeUrl))
            {
                string cssLinkCode = string.Format(
                    @"<link href='{0}' rel='stylesheet' type='text/css' />",
                    cssRelativeUrl);
                cs.RegisterClientScriptBlock(this.GetType(), cssRelativeUrl, cssLinkCode);
            }*/
        }
    }
}