namespace Cookies
{
    using System;
    using System.Web.UI;

    public partial class Index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var cookie = this.Request.Cookies["Username"];

            if (cookie == null)
            {
                this.Response.Redirect("Login.aspx");
            }
            else
            {
                this.LabelUsername.Text = cookie.Value;
            }
        }
    }
}