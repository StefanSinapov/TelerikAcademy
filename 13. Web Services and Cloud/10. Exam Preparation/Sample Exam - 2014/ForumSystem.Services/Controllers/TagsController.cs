namespace ForumSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Data.Contracts;
    using DataModels;

    public class TagsController : BaseApiController
    {
        public TagsController()
            : this(new ForumSystemData(ForumSystemDbContext.Create()))
        {

        }

        public TagsController(IForumSystemData data)
            : base(data)
        {

        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult Get()
        {
            var tags = this.Data.Tags.All().Select(TagDataModel.FromEntityToModel);

            return Ok(tags);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult GetById(int id)
        {
            var tag = this.Data.Tags.Find(id);

            if (tag == null)
            {
                return NotFound();
            }

            var articles = tag.Articles
                .AsQueryable()
                .OrderBy(a => a.DateCreated)
                .Select(ArticleByTagsDataModel.FromEntityToModel)
                .ToList();

            return Ok(articles);
        }
    }
}