namespace BugLogger.Repositories.Tests
{
    using System;
    using System.Linq;
    using System.Transactions;
    using Data;
    using Data.Repositories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class BugRepositoryTests
    {
        static TransactionScope tran;

        [TestInitialize]
        public void TestInit()
        {
            tran = new TransactionScope();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void AddBug_WhenBugIsValid_ShouldAddToDatabase()
        {
            // Arrange -> Prepare the objects
            var bug = this.GetValidTestBug();

            // Act -> Test the objects
            var bugRepository = new BugRepository(new BugLoggerDbContext());
            bugRepository.Add(bug);
            bugRepository.SaveChanges();

            // Assert -> Validate the result
            var bugFromDb = bugRepository.Find(bug.Id);

            Assert.IsNotNull(bugFromDb);
            Assert.AreEqual(bug, bugFromDb);
        }

        [TestMethod]
        public void DeleteBug_WbenBugIsInDB_SHoudRemoveFromDatabase()
        {
            // Arrange
            var bugRepository = new BugRepository(new BugLoggerDbContext());

            // Act
            var bug = bugRepository.All().First();
            var countBeforeDeletion = bugRepository.All().Count();
            bugRepository.Delete(bug);
            bugRepository.SaveChanges();

            // Assert
            var countAfterDeletion = bugRepository.All().Count();
            var bugFromDb = bugRepository.Find(bug.Id);

            Assert.AreEqual(countBeforeDeletion, countAfterDeletion + 1);
            Assert.IsNull(bugFromDb);
        }

        private Bug GetValidTestBug()
        {
            var bug = new Bug
            {
                Description = "Test Bug",
                LogDate = DateTime.Now,
                Status = BugStatus.Pending
            };

            return bug;
        }
    }
}
