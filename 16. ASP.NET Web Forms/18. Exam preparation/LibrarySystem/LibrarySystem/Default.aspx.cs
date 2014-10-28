namespace LibrarySystem
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Web.UI;

    using LibrarySystem.Models;

    public partial class _Default : Page
    {
        private readonly LibrarySystemDbContext context;

        public IEnumerable<Category> Select()
        {
            return this.context.Categories.Include("Books");
        }

        public _Default()
        {
            this.context = new LibrarySystemDbContext();
        }

        protected void ButtonSearch_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("~/Search?q={0}", this.TextBoxSearch.Text));
        }
    }
}