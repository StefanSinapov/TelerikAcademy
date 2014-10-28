using System;
using System.Web.UI;

namespace LibrarySystem
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.ModelBinding;

    using LibrarySystem.Models;

    public partial class Search : Page
    {

        private LibrarySystemDbContext context;

        public Search()
        {
            this.context = new LibrarySystemDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public IQueryable<Book> ReapeaterBooks_GetData([QueryString("q")] string query)
        {
            this.LiteralQuery.Text = query;
            var books = this.context.Books.Where(b => b.Author.Contains(query) || b.Title.Contains(query)).Include("Category");
            return books;
        }
    }
}