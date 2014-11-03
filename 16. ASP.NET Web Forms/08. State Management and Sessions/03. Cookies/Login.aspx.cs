namespace Cookies
{
    using System;
    using System.Web;
    using System.Web.UI;

    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            var cookie = Request.Cookies["Username"];

            if (cookie != null)
            {
                Response.Redirect("Index.aspx");
            }
        }

        protected void ButtonLogin_OnClick(object sender, EventArgs e)
        {
            var cookie = new HttpCookie("Username", this.TextBoxUsername.Text)
                             {
                                 Expires = DateTime.Now.AddMinutes(1)
                             };

            Response.Cookies.Add(cookie);
        }
    }
}