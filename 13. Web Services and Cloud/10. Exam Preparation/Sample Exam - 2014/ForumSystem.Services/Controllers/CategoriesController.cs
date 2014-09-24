namespace ForumSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Data.Contracts;
    using DataModels;

    public class CategoriesController : BaseApiController
    {
        public CategoriesController()
            : this(new ForumSystemData(ForumSystemDbContext.Create()))
        {

        }

        public CategoriesController(IForumSystemData data)
            : base(data)
        {
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult Get()
        {
            var categories = this.Data.Categories.All().Select(CategoryDataModel.FromEntityToModel);

            return Ok(categories);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult GetById(int id)
        {
            var category = this.Data.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            var articles = category.Articles
                    .AsQueryable()
                    .OrderBy(a => a.DateCreated)
                    .Select(ArticleDataModel.FromEntityToModel).ToList();

            return Ok(articles);
        }
    }
}