namespace Articles.Web
{
    using System;
    using System.Linq;
    using System.Web.ModelBinding;
    using System.Web.UI;

    using Articles.Web.Controls.LikeControl;
    using Articles.Web.Models;

    using Microsoft.AspNet.Identity;

    public partial class ViewArticle : Page
    {

        private ApplicationDbContext context;

        public ViewArticle()
        {
            this.context = new ApplicationDbContext();
        }

        public Article Select([QueryString("id")] int? id)
        {
            if (id == null)
            {
                Response.Redirect("/");
            }

            var article = this.context.Articles.Find(id);
            return article;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var likeCtrl = this.FormViewArticle.FindControl("LikeControl") as LikeControl;
                likeCtrl.Visible = true;
            }
        }

        protected void LikeControl_Like(object sender, LikeEventArgs e)
        {
            var article = this.context.Articles.Find(Convert.ToInt32(e.DataId));
            var userId = this.User.Identity.GetUserId();

            Like like = article.Likes.FirstOrDefault(l => l.UserId == userId);
            if (like == null)
            {
                like = new Like() { UserId = userId, ArticleId = Convert.ToInt32(e.DataId) };

                article.Likes.Add(like);
            }
            else
            {
                if (like.Value == true)
                {
                    article.LikesCount--;
                }
                else
                {
                    article.LikesCount++;
                }
            }

            like.Value = e.LikeValue;
            if (e.LikeValue)
            {
                article.LikesCount++;
            }
            else
            {
                article.LikesCount--;
            }

            this.context.SaveChanges();

            this.DataBind();
        }

        protected int GetLikesValue(Article item)
        {
            int likesCount = item.Likes.Count(l => l.Value == true);
            int hatesCount = item.Likes.Count(l => l.Value == false);
            return likesCount - hatesCount;
        }

        protected bool? GetUserVote(Article item)
        {
            string userId = this.User.Identity.GetUserId();
            var like = item.Likes.FirstOrDefault(l => l.UserId == userId);
            if (like == null)
            {
                return null;
            }

            return like.Value;
        }
    }
}