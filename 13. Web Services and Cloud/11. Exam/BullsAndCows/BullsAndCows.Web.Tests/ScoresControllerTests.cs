namespace BullsAndCows.Web.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using System.Web.Http.Routing;
    using BullsAndCows.Models;
    using Controllers;
    using Data.Contracts;
    using DataGenerators;
    using DataModels;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Telerik.JustMock;

    [TestClass]
    public class ScoresControllerTests
    {
        private const int DefaultPageSize = 10;
        private readonly UsersDataGenerator dataGenerator = new UsersDataGenerator();

        [TestMethod]
        public void GetScores_WhenUsersInDb_ShoudReturnTop10ByScore()
        {
            // Arrange
            var users = this.dataGenerator.GenereateUser(15);

            var usersRepo = Mock.Create<IRepository<User>>();
            var data = this.SetupUnitOfWork(usersRepo, users);
            var scoresController = this.SetupController(data);

            // Act
            var actionResult = scoresController.Get();
            var actionResponse = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var actual = actionResponse.Content.ReadAsAsync<IEnumerable<ScoreDataModel>>().Result.ToList();

            var expected = users.AsQueryable()
                                  .Select(ScoreDataModel.FromEntityToModel)
                                  .OrderBy( u => u.Rank)
                                  .Take(DefaultPageSize)
                                  .ToList();

            // Assert
            Assert.AreEqual(expected.Count, actual.Count);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Username, actual[i].Username);
            }
        }

        [TestMethod]
        public void GetScores_WhenUsersNoUser_ShoudReturnEmptyArray()
        {
            // Arrange
            var users = this.dataGenerator.GenereateUser(0);

            var usersRepo = Mock.Create<IRepository<User>>();
            var data = this.SetupUnitOfWork(usersRepo, users);
            var scoresController = this.SetupController(data);

            // Act
            var actionResult = scoresController.Get();
            var actionResponse = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var actual = actionResponse.Content.ReadAsAsync<IEnumerable<ScoreDataModel>>().Result.ToList();

            // Assert
            Assert.AreEqual(0, actual.Count);
        }

        private IBullsAndCowsData SetupUnitOfWork(IRepository<User> usersRepository, IEnumerable<User> users)
        {
            Mock.Arrange(() => usersRepository.All())
                .Returns(() => users.AsQueryable());

            var data = Mock.Create<IBullsAndCowsData>();
            Mock.Arrange(() => data.Users)
                .Returns(() => usersRepository);

            return data;
        }

        private ScoresController SetupController(IBullsAndCowsData data)
        {
            var scoresController = new ScoresController(data);
            this.SetupController(scoresController);
            return scoresController;
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
}