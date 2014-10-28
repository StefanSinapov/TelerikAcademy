namespace LibrarySystem
{
    using System;
    using System.Web.ModelBinding;
    using System.Web.UI;

    using LibrarySystem.Models;

    public partial class BookDetails : Page
    {
        private readonly LibrarySystemDbContext context;

        public BookDetails()
        {
            this.context = new LibrarySystemDbContext();
        }

        public Book Select([QueryString("id")] int? id)
        {
            if (id == null)
            {
                Response.Redirect("/");
            }

            var book = this.context.Books.Find(id);
            return book;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}