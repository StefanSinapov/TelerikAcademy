namespace LibrarySystem.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.UI;

    using Error_Handler_Control;

    using LibrarySystem.Models;

    public partial class EditBooks : Page
    {
        private readonly LibrarySystemDbContext context;

        public EditBooks()
        {
            this.context = new LibrarySystemDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Book> Select()
        {
            return this.context.Books.OrderBy(b => b.Title).Include("Category");
        }

        protected void ButtonShowCreatePanel_OnClick(object sender, EventArgs e)
        {
            this.ButtonShowCreatePanel.Visible = false;

            this.PanelCreate.Visible = true;
        }

        // TODO: book edit

        public void ListViewBooks_Delete(int id)
        {
            try
            {
                var book = this.context.Books.Find(id);

                if (book == null)
                {
                    ErrorSuccessNotifier.AddErrorMessage("Book with that id is not found");
                    return;
                }

                this.context.Books.Remove(book);
                this.context.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Book deleted!");
            }
            catch (Exception exception)
            {
                ErrorSuccessNotifier.AddErrorMessage("Failed to delete book" + exception.Message);
            }
        }

        protected void LinkButtonCreate_OnClick(object sender, EventArgs e)
        {
            this.PanelCreate.Visible = false;
            this.ButtonShowCreatePanel.Visible = true;

            try
            {
                var book = new Book
                {
                    Title = this.TextBoxTitleCreate.Text,
                    Author = this.TextBoxAuthorCreate.Text,
                    CategoryId = int.Parse(this.DropDownListCategoryCreate.SelectedValue),
                    Description = this.TextBoxDescriptionCreate.Text,
                    ISBN = this.TextBoxISBNCreate.Text,
                    WebSite = this.TextBoxWebSiteCreate.Text
                };

                this.context.Books.AddOrUpdate(book);
                this.context.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Book created.");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex.Message);
            }
        }

        protected void LinkButtonCancel_OnClick(object sender, EventArgs e)
        {
            this.ButtonShowCreatePanel.Visible = true;
            this.PanelCreate.Visible = false;
            this.PanelUpdate.Visible = false;
        }

        public IEnumerable<Category> DropDownListCategoryCreate_GetData()
        {
            return this.context.Categories;
        }

        protected void LinkButtonUpdate_OnClick(object sender, EventArgs e)
        {
            this.PanelUpdate.Visible = true;
        }

        public void Update(int id)
        {
            
        }
    }
}