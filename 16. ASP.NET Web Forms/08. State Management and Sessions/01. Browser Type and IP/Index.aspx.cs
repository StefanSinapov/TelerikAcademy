namespace BrowserTypeAndIP
{
    using System;
    using System.Web.UI;

    public partial class Index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LabelBrowser.Text = this.Request.Browser.Browser;
            this.LabelIpAddress.Text = Context.Request.UserHostAddress;
        }
    }
}