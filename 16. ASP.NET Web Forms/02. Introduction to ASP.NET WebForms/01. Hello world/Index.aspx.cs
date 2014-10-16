namespace _01.Hello_world
{
    using System;
    using System.Web.UI;

    public partial class Index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void PrintResult(object sender, EventArgs e)
        {
            lbResult.Text = "Hello " + tbName.Text;
        }
    }
}