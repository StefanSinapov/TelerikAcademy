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
    using BullsAndCows.Models.Enums;
    using Controllers;
    using Data.Contracts;
    using DataGenerators;
    using DataModels;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Telerik.JustMock;
    using Telerik.JustMock.Helpers;

    [TestClass]
    public class GamesControllerTests
    {
        private const int DefaultPageSize = 10;
        private readonly GamesDataGenerator dataGenerator = new GamesDataGenerator();

        [TestMethod]
        public void GetAllAvailableGames_WhenGamesInDb_ShoutReturnThem()
        {
            // Arrange
            var games = this.dataGenerator.GenereateGames(10);

            var gameRepo = Mock.Create<IRepository<Game>>();
            var data = this.SetupUnitOfWork(gameRepo, games);
            var gamesController = this.SetupController(data);

            // Act
            var actionResult = gamesController.GetPublic();
            var actionResponse = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var actual = actionResponse.Content.ReadAsAsync<IEnumerable<GameDataModel>>().Result.ToList();

            var expected = games
                    .Where(g => g.GameState == GameState.WaitingForOpponent)
                    .OrderBy(g => g.GameState)
                    .ThenBy(g => g.Name)
                    .ThenBy(g => g.DateCreated)
                    .ThenBy(g => g.RedPlayer.UserName)
                    .Take(DefaultPageSize)
                    .AsQueryable()
                    .Select(GameDataModel.FromEntityToModel)
                    .ToList();

            // Assert
            Assert.AreEqual(expected.Count(), actual.Count());
            Assert.AreEqual(10, actual.Count());

            for (int i = 0; i < expected.Count(); i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
            }
        }

        [TestMethod]
        public void GetAllAvailableGamesPage2_When16GamesInDb_ShoutReturn6Games()
        {
            // Arrange
            var games = this.dataGenerator.GenereateGames(16);

            var gameRepo = Mock.Create<IRepository<Game>>();
            var data = this.SetupUnitOfWork(gameRepo, games);
            var gamesController = this.SetupController(data);

            // Act
            var actionResult = gamesController.GetPublic(1);
            var actionResponse = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var actual = actionResponse.Content.ReadAsAsync<IEnumerable<GameDataModel>>().Result.ToList();

            // Assert
            Assert.AreEqual(6, actual.Count());
        }


        private IBullsAndCowsData SetupUnitOfWork(IRepository<Game> gamesRepository, IEnumerable<Game> games)
        {
            Mock.Arrange(() => gamesRepository.All())
                .Returns(() => games.AsQueryable());

            var data = Mock.Create<IBullsAndCowsData>();
            Mock.Arrange(() => data.Games)
                .Returns(() => gamesRepository);

            return data;
        }

        private GamesController SetupController(IBullsAndCowsData data)
        {
            var scoresController = new GamesController(data);
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