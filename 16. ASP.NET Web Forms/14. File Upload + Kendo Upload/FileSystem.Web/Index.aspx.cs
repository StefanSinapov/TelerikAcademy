namespace FileSystem.Web
{
    using System;
    using System.Linq;
    using System.Web.UI;

    using FileSystem.Data;

    public partial class Index : Page
    {
        private readonly FileSysteDbContext data = new FileSysteDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.RepeaterContent.DataSource = this.data.FileContents.ToList();
            this.RepeaterContent.DataBind();
        }
    }
}