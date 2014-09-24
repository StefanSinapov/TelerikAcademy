namespace ForumSystem.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Data.Contracts;
    using DataModels;
    using ForumSystem.Models;

    public class ArticlesController : BaseApiController
    {
        private const int DefaultPageSize = 10;

        public ArticlesController()
            : this(new ForumSystemData(ForumSystemDbContext.Create()))
        {
            
        }

        public ArticlesController(IForumSystemData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var articles = this.Data.Articles
                              .All()
                              .OrderBy(a => a.DateCreated)
                              .Select(ArticleDataModel.FromEntityToModel)
                              .Take(DefaultPageSize);

            return this.Ok(articles);
        }

        [HttpGet]
        public IQueryable<ArticleDataModel> Get(int? page)
        {
            return this.Get(string.Empty, page);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult Get(int id)
        {
            var article = this.GetArticleDetailsById(id);
            if (article == null)
            {
                return this.ReturnBadRequestIfNull(id);
            }

            return this.Ok(article);
        }

        
        [HttpGet]
        [Authorize]
        public IQueryable<ArticleDataModel> Get(string category)
        {
            return this.Get(category, 0);
        }

        [HttpGet]
        [Authorize]
        public IQueryable<ArticleDataModel> Get(string category, int? page)
        {
            var articles = this.Data.Articles.All();

            if (!string.IsNullOrEmpty(category))
            {
                articles = articles.Where(a => a.Category.Name == category);
            }

            articles = articles.OrderBy(a => a.DateCreated);

            if (page.HasValue)
            {
                articles = articles.Skip(page.Value * DefaultPageSize);
            }

            return articles.Select(ArticleDataModel.FromEntityToModel)
                           .Take(DefaultPageSize);
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(ArticleDataModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(model.Content))
            {
                return BadRequest("Article content cannot be null or empty");
            }

            if (string.IsNullOrEmpty(model.Title))
            {
                return BadRequest("Article content cannot be null or empty");
            }

            var tags = this.GetTags(model);
            var categoryId = this.GetCategoryId(model.Category);

            var article = new Article
            {
                CategoryId = categoryId,
                Content = model.Content,
                Title = model.Title,
                DateCreated = DateTime.Now,
                Tags = tags,
                UserId = this.GetUserId()
            };

            this.Data.Articles.Add(article);
            this.Data.SaveChanges();

            model.Id = article.Id;
            model.DateCreated = article.DateCreated;
            model.Tags = article.Tags.AsQueryable().Select(TagDataModel.FromEntityToModel).ToList();

            return Ok(model);
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult PostComment(int id)
        {
            var article = this.GetArticleById(id);
            if (article == null)
            {
                return this.ReturnBadRequestIfNull(id);
            }

            return this.Ok();
        }

        private ArticleDataModel GetArticleById(int id)
        {
            var article = this.Data.Articles
                              .All()
                              .Select(ArticleDataModel.FromEntityToModel)
                              .FirstOrDefault(a => a.Id == id);
            return article;
        }

        private ArticleDetailsDataModel GetArticleDetailsById(int id)
        {
            var article = this.Data.Articles
                              .All()
                              .Select(ArticleDetailsDataModel.FromEntityToModel)
                              .FirstOrDefault(a => a.Id == id);
            return article;
        }


        private ICollection<Tag> GetTags(ArticleDataModel article)
        {
            var allTags = new HashSet<string>();
            allTags.UnionWith(article.Tags.Select(t => t.Name));
            allTags.UnionWith(article.Title.Split(' '));

            var tags = new HashSet<Tag>();

            foreach (var tagName in allTags)
            {
                var tag = this.Data.Tags
                            .All()
                            .FirstOrDefault(t => t.Name == tagName);

                if (tag == null)
                {
                    tag = new Tag
                    {
                        Name = tagName
                    };

                    this.Data.Tags.Add(tag);
                    this.Data.SaveChanges();
                }

                tags.Add(tag);
            }

            return tags;
        }

        private int GetCategoryId(string categoryName)
        {
            var category = this.Data.Categories
                               .All()
                               .FirstOrDefault(c => c.Name == categoryName);

            if (category == null)
            {
                category = new Category
                {
                    Name = categoryName
                };

                this.Data.Categories.Add(category);
                this.Data.SaveChanges();
            }

            return category.Id;
        }

        private IHttpActionResult ReturnBadRequestIfNull(int id)
        {
            return this.BadRequest(string.Format("Article with id={0} does not exists!", id));
        }
    }
}