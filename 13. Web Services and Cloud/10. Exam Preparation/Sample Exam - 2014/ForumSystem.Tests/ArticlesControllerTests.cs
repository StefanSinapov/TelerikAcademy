namespace ForumSystem.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using System.Web.Http.Routing;
    using Data.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Services.Controllers;
    using Services.DataModels;
    using Telerik.JustMock;

    [TestClass]
    public class ArticlesControllerTests
    {
        private const int DefaultPageSize = 10;
        private readonly DataGenerator dataGenerator = new DataGenerator();

        [TestMethod]
        public void GetArticles_WhenArticlesInDb_ShoudReturn10Articles()
        {
            // Arrange
            var articles = this.dataGenerator.GenerateArticles(DefaultPageSize);

            var articlesRepository = Mock.Create<IRepository<Article>>();
            var forumSystemData = this.SetupUnitOfWork(articlesRepository, articles);
            var articlesController = this.SetupController(forumSystemData);

            // Act
            var actionResult = articlesController.Get();
            var actionResponse = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var actual = actionResponse.Content.ReadAsAsync<IEnumerable<ArticleDataModel>>().Result.ToList();
            var expected = articles.AsQueryable()
                                   .Select(ArticleDataModel.FromEntityToModel)
                                   .OrderBy(a => a.DateCreated)
                                   .Take(DefaultPageSize)
                                   .ToList();

            // Assert
            Assert.AreEqual(DefaultPageSize, actual.Count());
            for (int i = 0; i < DefaultPageSize; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
            }
        }

        private IForumSystemData SetupUnitOfWork(IRepository<Article> articlesRepository, IEnumerable<Article> articles)
        {
            Mock.Arrange(() => articlesRepository.All())
                .Returns(() => articles.AsQueryable());

            var forumSystemData = Mock.Create<IForumSystemData>();
            Mock.Arrange(() => forumSystemData.Articles)
                .Returns(() => articlesRepository);

            return forumSystemData;
        }

        private ArticlesController SetupController(IForumSystemData forumSystemData)
        {
            var articlesController = new ArticlesController(forumSystemData);
            this.SetupController(articlesController);
            return articlesController;
        }

        private void SetupController(ApiController controller)
        {
            const string serverUrl = "http://test-url.com";

            // Setup the Request object of the controller
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(serverUrl)
            };
            controller.Request = request;

            // Setup the configuration of the controller
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

            // Apply the routes of the controller
            controller.RequestContext.RouteData =
                new HttpRouteData(
                    route: new HttpRoute(),
                    values: new HttpRouteValueDictionary
                    {
                        { "controller", "Articles" }
                    });
        }
    }

    internal class DataGenerator
    {
        private static readonly Random rnd = new Random();

        public IList<Article> GenerateArticles(int count)
        {
            var category = this.GenerateCategory();
            var tags = this.GenerateTagsCollection();

            var articles = new List<Article>();
            for (int i = 0; i < count; i++)
            {
                var article = new Article
                {
                    Id = i,
                    Title = "Title #" + i,
                    Content = "Content #" + i,
                    Category = category,
                    DateCreated = DateTime.Now.AddHours(rnd.Next(-5 * 365, 5 * 365)),
                    Tags = tags,
                    User = new User()
                };

                articles.Add(article);
            }

            return articles;
        }

        public Category GenerateCategory()
        {
            var category = new Category
            {
                Name = "test-category"
            };

            return category;
        }

        public IList<Tag> GenerateTagsCollection()
        {
            var tags = new List<Tag>
            {
                new Tag
                {
                    Id = 1,
                    Name = "test-tag"
                }
            };

            return tags;
        }
    }
}