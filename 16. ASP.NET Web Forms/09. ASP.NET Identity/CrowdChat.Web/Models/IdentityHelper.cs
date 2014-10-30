namespace CrowdChat.Web.Models
{
    using System;
    using System.Security.Claims;
    using System.Web;

    using CrowdChat.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;

    /// <summary>
    /// The identity helper.
    /// </summary>
    public static class IdentityHelper
    {
        // Used for XSRF when linking external logins
        #region Constants

        public const string CodeKey = "code";

        public const string ProviderNameKey = "providerName";

        public const string UserIdKey = "userId";

        public const string XsrfKey = "XsrfId";

        #endregion

        #region Public Methods and Operators

        public static string GetCodeFromRequest(HttpRequest request)
        {
            return request.QueryString[CodeKey];
        }

        public static string GetProviderNameFromRequest(HttpRequest request)
        {
            return request.QueryString[ProviderNameKey];
        }

        public static string GetResetPasswordRedirectUrl(string code, HttpRequest request)
        {
            string absoluteUri = "/Account/ResetPassword?" + CodeKey + "=" + HttpUtility.UrlEncode(code);
            return new Uri(request.Url, absoluteUri).AbsoluteUri;
        }

        public static string GetUserConfirmationRedirectUrl(string code, string userId, HttpRequest request)
        {
            string absoluteUri = "/Account/Confirm?" + CodeKey + "=" + HttpUtility.UrlEncode(code) + "&" + UserIdKey
                                 + "=" + HttpUtility.UrlEncode(userId);
            return new Uri(request.Url, absoluteUri).AbsoluteUri;
        }

        public static string GetUserIdFromRequest(HttpRequest request)
        {
            return HttpUtility.UrlDecode(request.QueryString[UserIdKey]);
        }

        public static void RedirectToReturnUrl(string returnUrl, HttpResponse response)
        {
            if (!string.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
            {
                response.Redirect(returnUrl);
            }
            else
            {
                response.Redirect("~/");
            }
        }

        public static void SignIn(UserManager manager, User user, bool isPersistent)
        {
            IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            ClaimsIdentity identity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, identity);
        }

        #endregion

        #region Methods

        private static bool IsLocalUrl(string url)
        {
            return !string.IsNullOrEmpty(url)
                   && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\')))
                       || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
        }

        #endregion
    }
}