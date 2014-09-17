using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Places.Models;
using Places.Repositories;
using Telerik.JustMock;
using System.Net;

namespace Places.Services.IntergrationTests
{
    [TestClass]
    public class CategoriesControllerIntegrationTests
    {
        [TestMethod]
        public void GetAll_WhenOneCategory_ShouldReturnStatusCode200AndNotNullContent()
        {
            var mockRepository = Mock.Create<IRepository<Category>>();
            var models = new List<Category>();
            models.Add(new Category()
            {
                Name = "Test Cat"
            });

            Mock.Arrange(() => mockRepository.All())
                .Returns(() => models.AsQueryable());

            var server = new InMemoryHttpServer<Category>("http://localhost/",
                mockRepository);

            var response = server.CreateGetRequest("api/categories");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void PostCategory_WhenNameIsNull_ShouldReturnStatusCode400()
        {
            var mockRepository = Mock.Create<IRepository<Category>>();

            Mock.Arrange(() => mockRepository
                .Add(Arg.Matches<Category>(cat => cat.Name == null)))
                    .Throws<NullReferenceException>();


            var server =
                new InMemoryHttpServer<Category>("http://localhost/", mockRepository);

            var response = server.CreatePostRequest("api/categories",
                new Category()
                {
                    Name = null
                });

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
