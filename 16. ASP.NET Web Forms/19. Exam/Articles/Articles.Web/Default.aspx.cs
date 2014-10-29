namespace Articles.Web
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.UI;

    using Articles.Web.Models;

    public partial class _Default : Page
    {
        private ApplicationDbContext context;
        private const int MostPopularCount = 3;

        public _Default()
        {
            this.context = new ApplicationDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // TODO: Order by popular
        public IQueryable<Article> ListViewMostPupular_GetData()
        {
            var articles = this.context.Articles.OrderByDescending(a => a.LikesCount).Take(MostPopularCount);

            return articles;
        }

        public IQueryable<Category> ListViewCategories_GetData()
        {
            return this.context.Categories.Include("Articles");
        }
    }
}