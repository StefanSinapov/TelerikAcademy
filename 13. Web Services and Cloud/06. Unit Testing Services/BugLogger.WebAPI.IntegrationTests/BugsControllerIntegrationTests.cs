namespace BugLogger.WebAPI.IntegrationTests
{
    using System;
    using System.Net;
    using Data.Contracts;
    using DataModels;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Server;
    using Telerik.JustMock;

    [TestClass]
    public class BugsControllerIntegrationTests
    {
        private const string InMemoryServerUrl = "http://localhost:4444";

        [TestMethod]
        public void GetAll_WheneAreBugsInDb_ShoudReturnStatus200AndNonEmptyContext()
        {
            // Arrange
            var bugLoggerData = this.MockUnitOfWorkForActionAll();
            var server = new InMemoryHttpServer<Bug>(InMemoryServerUrl, bugLoggerData);

            // Act
            var response = server.CreateGetRequest("/api/Bugs/All");

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void PostNewBug_WhenBugIsValid_ShoudReturnStatus201()
        {
            // Arrange
            var bugLoggerData = this.MockUnitOfWorkForActionAll();
            var bug = new CreateBugModel
            {
                Description = "bug-1",
                LogDate = DateTime.Now,
                Status = BugStatus.Pending
            };
            var server = new InMemoryHttpServer<Bug>(InMemoryServerUrl, bugLoggerData);

            // Act
            var response = server.CreatePostRequest("/api/Bugs/Create", bug);

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public void PostNewBug_WhenDescriptionIsEmpty_ShoudReturnStatus400()
        {
            // Arrange
            var bugLoggerData = this.MockUnitOfWorkForActionAll();
            var bug = new CreateBugModel
            {
                Description = string.Empty,
                LogDate = DateTime.Now
            };
            var server = new InMemoryHttpServer<Bug>(InMemoryServerUrl, bugLoggerData);

            // Act
            var response = server.CreatePostRequest("/api/bugs/Create", bug);

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }


        [TestMethod]
        public void PostNewBugWhenDescriptionIsEmptyShouldReturn400()
        {
            var bugLoggerData = this.MockUnitOfWorkForActionAll();
            var bug = new CreateBugModel
            {
                Description = string.Empty,
                LogDate = DateTime.Now
            };

            var server = new InMemoryHttpServer<Bug>(InMemoryServerUrl, bugLoggerData);
            var response = server.CreatePostRequest("/api/Bugs/Create", bug);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void PostNewBugWhenDescriptionIsNullShouldReturn400()
        {
            var bugLoggerData = this.MockUnitOfWorkForActionAll();
            var bug = new CreateBugModel
            {
                Description = null,
                LogDate = DateTime.Now
            };

            var server = new InMemoryHttpServer<Bug>(InMemoryServerUrl, bugLoggerData);
            var response = server.CreatePostRequest("/api/Bugs/Create", bug);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void PostNewBugWithoutLogDateShouldReturn400()
        {
            var bugLoggerData = this.MockUnitOfWorkForActionAll();
            var bug = new CreateBugModel
            {
                Description = "bug-1",
            };

            var server = new InMemoryHttpServer<Bug>(InMemoryServerUrl, bugLoggerData);
            var response = server.CreatePostRequest("/api/Bugs/Create", bug);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void PostNewBugWithoutLogDateAndEmptyDescriptionShouldReturn400()
        {
            var bugLoggerData = this.MockUnitOfWorkForActionAll();
            var bug = new CreateBugModel();

            var server = new InMemoryHttpServer<Bug>(InMemoryServerUrl, bugLoggerData);
            var response = server.CreatePostRequest("/api/Bugs/Create", bug);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }


        private IBugLoggerData MockUnitOfWorkForActionAll()
        {
            var bugFakeRepository = Mock.Create<IBugRepository>();
            var bugLoggerData = Mock.Create<IBugLoggerData>();
            Mock.Arrange(() => bugLoggerData.Bugs)
                .Returns(() => bugFakeRepository);

            return bugLoggerData;
        }
    }
}