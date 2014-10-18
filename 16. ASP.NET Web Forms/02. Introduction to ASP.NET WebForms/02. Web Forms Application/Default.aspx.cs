namespace _02.Web_Forms_Application
{
    using System;
    using System.Reflection;
    using System.Web.UI;

    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.headerFromCode.InnerText = "Hello from code behind";
            this.spanAssembyLoc.InnerText = Assembly.GetExecutingAssembly().Location;
        }
    }
}