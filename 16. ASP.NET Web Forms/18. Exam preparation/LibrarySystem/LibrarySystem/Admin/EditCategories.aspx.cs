namespace LibrarySystem.Admin
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.UI;

    using Error_Handler_Control;

    using LibrarySystem.Models;

    public partial class EditCategories : Page
    {
        private readonly LibrarySystemDbContext context;

        public EditCategories()
        {
            this.context = new LibrarySystemDbContext();
        }

        public IQueryable<Category> Select()
        {
            return this.context.Categories.OrderBy(c => c.Name);
        }

        public void Delete(int id)
        {
            try
            {
                var category = this.context.Categories.Find(id);

                this.context.Categories.Remove(category);
                this.context.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Category deleted.");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex.Message);
            }
        }

        public void Update(int id)
        {
            var item = this.context.Categories.Find(id);

            if (item == null)
            {
                // The item wasn't found
                ErrorSuccessNotifier.AddErrorMessage(string.Format("Item with id {0} was not found", id));
                return;
            }

            this.TryUpdateModel(item);

            if (ModelState.IsValid)
            {
                this.context.SaveChanges();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LinkButtonCreate_OnClick(object sender, EventArgs e)
        {
            this.PanelCreate.Visible = false;
            this.ButtonShowCreatePanel.Visible = true;
            var name = this.TextBoxCategoryCreate.Text;

            if (name != string.Empty)
            {
                try
                {
                    var category = new Category { Name = name };

                    this.context.Categories.AddOrUpdate(category);
                    this.context.SaveChanges();
                    ErrorSuccessNotifier.AddSuccessMessage("Category created.");
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex.Message);
                }
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage("Category name cannot be empty.");
            }   
        }

        protected void LinkButtonCancel_OnClick(object sender, EventArgs e)
        {
            this.ButtonShowCreatePanel.Visible = true;
            this.PanelCreate.Visible = false;
        }

        protected void ButtonShowCreatePanel_OnClick(object sender, EventArgs e)
        {
            this.ButtonShowCreatePanel.Visible = false;
            this.PanelCreate.Visible = true;
        }
    }
}