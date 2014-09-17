using System;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using Places.Repositories;
using Places.Models;
using System.Linq;
using System.Collections.Generic;
using Places.Services.Controllers;
using Places.Services.Models;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using System.Web.Http.Controllers;
using Places.Services.Tests.Fakes;

namespace Places.Services.Tests.Controllers.Tests
{
    [TestClass]
    public class CategoriesControllerTests
    {
        private void SetupController(ApiController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/categories");
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", "categories");
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }

        [TestMethod]
        public void Add_WhenNameIsValid_ShouldAddTheCategory()
        {
            bool isItemAdded = false;
            var repository = Mock.Create<IRepository<Category>>();

            var categoryModel = new CategoryModel()
            {
                Name = "NEW TEST NAME"
            };
            var categoryEntity = new Category()
            {
                Id = 1,
                Name = categoryModel.Name
            };
            Mock.Arrange(() => repository.Add(Arg.IsAny<Category>()))
                .DoInstead(() => isItemAdded = true)
                .Returns(categoryEntity);

            var controller = new CategoriesController(repository);
            SetupController(controller);

            controller.PostCategory(categoryModel);

            Assert.IsTrue(isItemAdded);
        }

        [TestMethod]
        public void GetAll_WhenASingleCategoryInRepository_ShouldReturnSingleCategory()
        {
            var repository = Mock.Create<IRepository<Category>>();            
            var categoryToAdd = new Category()
            {
                Name = "Test category"
            };
            IList<Category> categoryEntities = new List<Category>();
            categoryEntities.Add(categoryToAdd);
            Mock.Arrange(() => repository.All()).Returns(() => categoryEntities.AsQueryable());

            var controller = new CategoriesController(repository);

            var categoryModels = controller.GetAll();
            Assert.IsTrue(categoryModels.Count() == 1);
            Assert.AreEqual(categoryToAdd.Name, categoryModels.First().Name);
        }

        [TestMethod]
        public void GetAllCategories_WhenASingleCategoryInRepository_ShouldReturnSingleCategory()
        {
            var repository = new FakeRepository<Category>();

            var categoryToAdd = new Category()
            {
                Name = "Test category"
            };
            repository.entities.Add(categoryToAdd);

            var controller = new CategoriesController(repository);

            var categoriesModels = controller.GetAll();
            Assert.IsTrue(categoriesModels.Count() == 1);
            Assert.AreEqual(categoryToAdd.Name, categoriesModels.First().Name);
        }
    }
}