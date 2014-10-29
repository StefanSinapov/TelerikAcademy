﻿namespace Articles.Web.Admin
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.ModelBinding;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Articles.Web.Controls.ErrorSuccessNotifier;
    using Articles.Web.Extensions;
    using Articles.Web.Models;

    using Microsoft.AspNet.Identity;

    public partial class EditArticles : Page
    {
        private readonly ApplicationDbContext context;

        public EditArticles()
        {
            this.context = new ApplicationDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonShowCreatePanel_OnClick(object sender, EventArgs e)
        {
            this.PanelCreate.Visible = true;
            this.TextBoxTitle.Focus();
        }

        public IQueryable<Article> Select([ViewState("OrderBy")]string OrderBy = null)
        {
            var list = this.context.Articles.AsQueryable();

            if (OrderBy != null)
            {
                switch (this.SortDirection)
                {
                    case SortDirection.Ascending:
                        list = list.OrderByDescending(OrderBy);
                        break;
                    case SortDirection.Descending:
                        list = list.OrderBy(OrderBy);
                        break;
                    default:
                        list = list.OrderByDescending(OrderBy);
                        break;
                }
            }

            return list;
        }

        public SortDirection SortDirection
        {
            get
            {
                if (this.ViewState["IsSorting"] != null)
                {

                    if ((bool)ViewState["IsSorting"] == false)
                    {
                        if (ViewState["sortdirection"] == null)
                        {
                            ViewState["sortdirection"] = SortDirection.Ascending;
                            return SortDirection.Ascending;
                        }
                        else if ((SortDirection)ViewState["sortdirection"] == SortDirection.Ascending)
                        {
                            return SortDirection.Ascending;
                        }
                        else
                        {
                            return SortDirection.Descending;
                        }
                    }
                }

                if (ViewState["sortdirection"] == null)
                {
                    ViewState["sortdirection"] = SortDirection.Ascending;
                    return SortDirection.Ascending;
                }
                else if ((SortDirection)ViewState["sortdirection"] == SortDirection.Ascending)
                {
                    ViewState["sortdirection"] = SortDirection.Descending;
                    return SortDirection.Descending;
                }
                else
                {
                    ViewState["sortdirection"] = SortDirection.Ascending;
                    return SortDirection.Ascending;
                }
            }
            set
            {
                ViewState["sortdirection"] = value;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var article = this.context.Articles.Find(id);

                this.context.Articles.Remove(article);
                this.context.SaveChanges();

                ErrorSuccessNotifier.AddSuccessMessage("Article deleted");
            }
            catch (Exception exception)
            {
                ErrorSuccessNotifier.AddErrorMessage(exception.Message);
            }
        }

        public void Update(int id)
        {
            var item = this.context.Articles.Find(id);

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

        public IQueryable<Category> DropDownListCategories_GetData()
        {
            return this.context.Categories;
        }

        protected void LinkButtonCreate_OnClick(object sender, EventArgs e)
        {
            this.PanelCreate.Visible = false;

            var userId = this.User.Identity.GetUserId();
            var user = this.context.Users.Find(userId);

            try
            {
                var article = new Article
                {
                    Title = this.TextBoxTitle.Text,
                    Author = user,
                    CategoryId = int.Parse(this.DropDownListCategory.SelectedValue),
                    Content = this.TextBoxContent.Text,
                    DateCreated = DateTime.Now
                };

                this.context.Articles.AddOrUpdate(article);
                this.context.SaveChanges();
                this.ListViewArticles.DataBind();
                ErrorSuccessNotifier.AddSuccessMessage("Article created successfully.");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex.Message);
            }
        }

        protected void LinkButtonCancel_OnClick(object sender, EventArgs e)
        {
            this.PanelCreate.Visible = false;
        }

        protected void ListViewArticles_OnSorting(object sender, ListViewSortEventArgs e)
        {
            e.Cancel = true;
            ViewState["OrderBy"] = e.SortExpression;
            ViewState["IsSorting"] = true;
            this.ListViewArticles.DataBind();
        }

        protected void ListViewArticles_OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            ViewState["IsSorting"] = false;
        }
    }
}