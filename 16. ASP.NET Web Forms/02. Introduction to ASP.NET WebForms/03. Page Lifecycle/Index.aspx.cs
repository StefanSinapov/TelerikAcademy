namespace _03.Page_Lifecycle
{
    using System;
    using System.Web.UI;

    public partial class Index : Page
    {
        protected override void OnInit(EventArgs e)
        {
            Response.Write("ON INIT invoked" + "<br/>");
            base.OnInit(e);
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Response.Write("Page_PreInit invoked" + "<br/>");
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Write("Page_Init invoked" + "<br/>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Page_Load invoked" + "<br/>");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Write("Page_PreRender invoked" + "<br/>");
        }

        protected void ButtonOkInit(object sender, EventArgs e)
        {
            Response.Write("ButtonOK_Init invoked" + "<br/>");
        }

        protected void ButtonOkLoad(object sender, EventArgs e)
        {
            Response.Write("ButtonOK_Load invoked" + "<br/>");
        }

        protected void ButtonOkClick(object sender, EventArgs e)
        {
            Response.Write("ButtonOK_Click invoked" + "<br/>");
        }

        protected void ButtonOkPreRender(object sender, EventArgs e)
        {
            Response.Write("ButtonOK_PreRender invoked" + "<br/>");
        }
    }
}