namespace BugLogger.WebAPI.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Routing;
    using Controllers;
    using Data.Contracts;
    using DataModels;
    using Fakes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Telerik.JustMock;

    [TestClass]
    public class BugsControllerTests
    {
        [TestMethod]
        public void GetAllBugs_FromController_ShouldReturnAllFakeBugs()
        {
            // Arrange
            var bugs = this.GenerateBugsCollection();
            var bugLoggerFakeData = new BugLoggerFakeData();

            foreach (var bug in bugs)
            {
                bugLoggerFakeData.Bugs.Add(bug);
            }

            var bugsController = new BugsController(bugLoggerFakeData);

            // Act
            var result = bugsController.All();

            // Assert
            Assert.AreEqual(bugs.Count, result.Count());

            var resultList = result.ToList();
            for (int i = 0; i < bugs.Count; i++)
            {
                Assert.AreEqual(bugs[i].Description, resultList[i].Description);
                Assert.AreEqual(bugs[i].LogDate, resultList[i].LogDate);
            }
        }

        [TestMethod]
        public void AddingValidBug_WithAPI_ShoudBeAddedToRepository()
        {
            // Arrange
            var bugLoggerFakeData = new BugLoggerFakeData();
            var bug = new CreateBugModel
            {
                Description = "Valid-bug-1",
                LogDate = DateTime.Now.AddDays(-2),
            };

            var bugsController = new BugsController(bugLoggerFakeData);
            this.SetupController(bugsController);

            // Act
            bugsController.Create(bug);

            // Assert
            Assert.AreEqual(1, bugLoggerFakeData.Bugs.All().Count());

            var bugsInDb = bugLoggerFakeData.Bugs.All().First();
            Assert.AreEqual(bug.Description, bugsInDb.Description);
            Assert.AreEqual(bug.LogDate, bugsInDb.LogDate);
            Assert.IsNotNull(bug.LogDate);
            Assert.IsTrue(bugLoggerFakeData.IsSaveChangesCalled);
        }


        [TestMethod]
        public void AddBug_WithEmptyDescription_ShoudNotBeAddedToRepository()
        {
            // Arrange
            var bugLoggerData = new BugLoggerFakeData();
            var bug = new CreateBugModel
            {
                LogDate = DateTime.Now
            };
            var bugsController = new BugsController(bugLoggerData);
            this.SetupController(bugsController);

            // Act
            bugsController.Create(bug);

            // Assert
            Assert.AreEqual(0, bugLoggerData.Bugs.All().Count());
        }

        [TestMethod]
        public void AddBugWithNullDescriptionShouldNotBeAddedToRepository()
        {
            // Arrange
            var bugLoggerFakeData = new BugLoggerFakeData();
            var bug = new CreateBugModel
            {
                Description = null,
                LogDate = DateTime.Now
            };

            var bugsController = new BugsController(bugLoggerFakeData);
            this.SetupController(bugsController);

            // Act
            bugsController.Create(bug);

            // Assert
            Assert.AreEqual(bugLoggerFakeData.Bugs.All().Count(), 0);
        }

        [TestMethod]
        public void AddBugWithValidDescriptionAndWithoutLogDateShouldNotBeAddedToRepository()
        {
            // Arrange
            var bugLoggerFakeData = new BugLoggerFakeData();
            var bug = new CreateBugModel
            {
                Description = "bug-1"
            };

            var bugsController = new BugsController(bugLoggerFakeData);
            this.SetupController(bugsController);

            // Act
            bugsController.Create(bug);

            // Assert
            Assert.AreEqual(bugLoggerFakeData.Bugs.All().Count(), 0);
        }

        [TestMethod]
        public void AddBugWithoutBothDescriptionAndLogDateShouldNotBeAddedToRepository()
        {
            // Arrange
            var bugLoggerFakeData = new BugLoggerFakeData();
            var bug = new CreateBugModel();

            var bugsController = new BugsController(bugLoggerFakeData);
            this.SetupController(bugsController);

            // Act
            bugsController.Create(bug);

            // Assert
            Assert.AreEqual(bugLoggerFakeData.Bugs.All().Count(), 0);
        }

        [TestMethod]
        public void AddValidBugShouldBeAddedToRepository_Mocking()
        {
            // Arrange
            var bug = new CreateBugModel
            {
                Description = "bug-1",
                LogDate = DateTime.Now,
                Status = BugStatus.Pending
            };

            var bugs = new List<Bug>();
            var bugLoggerFakeData = this.MockUnitOfWorkForActionAll(bugs);
            var bugsController = new BugsController(bugLoggerFakeData);
            this.SetupController(bugsController);

            // Act
            bugsController.Create(bug);

            // Assert
            Assert.AreEqual(bugLoggerFakeData.Bugs.All().Count(), 1);

            var bugInDatabase = bugLoggerFakeData.Bugs.All().First();
            Assert.AreEqual(bug.Description, bugInDatabase.Description);
            Assert.AreEqual(BugStatus.Pending, bugInDatabase.Status);
            Assert.IsNotNull(bugInDatabase.LogDate);
        }

        private IList<Bug> GenerateBugsCollection()
        {
            var bugs = new List<Bug>
            {
                new Bug
                {
                    Id = 1,
                    Description = "Test-bug-1"
                },
                new Bug
                {
                    Id = 2,
                    Description = "Test-bug-2"
                },
                new Bug
                {
                    Id = 3,
                    Description = "Test-bug-3"
                }
            };

            return bugs;
        }

        private IBugLoggerData MockUnitOfWorkForActionAll(IList<Bug> bugs)
        {
            var bugFakeRepository = Mock.Create<IBugRepository>();

            Mock.Arrange(() => bugFakeRepository.All())
                .Returns(bugs.AsQueryable);

            Mock.Arrange(() => bugFakeRepository.Add(Arg.IsAny<Bug>()))
                .DoInstead<Bug>(bugs.Add);

            var bugLoggerData = Mock.Create<IBugLoggerData>();
            Mock.Arrange(() => bugLoggerData.Bugs)
                .Returns(() => bugFakeRepository);

            return bugLoggerData;
        }

        private void SetupController(ApiController controller)
        {
            const string serverUrl = "http://test-url.com";

            // Setup the Request object of the controller
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(serverUrl)
            };
            controller.Request = request;

            // Setup the configuration of the controller
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

            // Apply the routes of the controller
            controller.RequestContext.RouteData =
                new HttpRouteData(
                    route: new HttpRoute(),
                    values: new HttpRouteValueDictionary
                    {
                        { "controller", "Bugs" }
                    });
        }
    }
}