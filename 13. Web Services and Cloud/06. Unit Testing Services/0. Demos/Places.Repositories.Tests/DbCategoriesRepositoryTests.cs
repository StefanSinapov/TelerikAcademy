using System;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Places.DataLayer;
using Places.Models;
using Places.Repositories;
using System.Data.Entity;

namespace Places.Repositories.Tests
{
    [TestClass]
    public class DbCategoriesRepositoryTests
    {
        public DbContext dbContext { get; set; }

        static Random rand = new Random();

        public IRepository<Category> categoriesRepository { get; set; }

        private static TransactionScope tranScope;

        public DbCategoriesRepositoryTests()
        {
            this.dbContext = new PlacesContext();
            this.categoriesRepository = new DbCategoryRepository(this.dbContext);
        }

        [TestInitialize]
        public void TestInit()
        {
            tranScope = new TransactionScope();
        }

        [TestCleanup]
        public void TestTearDown()
        {
            tranScope.Dispose();
        }

        [TestMethod]
        public void MyTestMethod2()
        {
            var cat = new Category()
            {
                Name = "TEST EDI KVO SI "
            };
            dbContext.Set<Category>().Add(cat);
            dbContext.SaveChanges();
            Assert.IsTrue(cat.Id > 0);
        }

        [TestMethod]
        public void Add_WhenNameIsValid_ShouldAddCategoryToDatabase()
        {
            //using (TransactionScope scope = new TransactionScope())
            //{
            var categoryName = "Test category";
            var category = new Category()
            {
                Name = categoryName
            };

            var createdCategory = this.categoriesRepository.Add(category);
            var foundCategory = this.dbContext.Set<Category>().Find(createdCategory.Id);
            Assert.IsNotNull(foundCategory);
            Assert.AreEqual(categoryName, foundCategory.Name);
            //}
        }

        [TestMethod]
        public void Add_WhenNameIsValid_ShouldReturnNotZeroId()
        {
            //using (TransactionScope scope = new TransactionScope())
            //{
            var categoryName = "Test category";
            var category = new Category()
            {
                Name = categoryName
            };

            var createdCategory = this.categoriesRepository.Add(category);
            Assert.IsTrue(createdCategory.Id != 0);
            //}
        }

        [TestMethod]
        public void MyTestMethod()
        {
            int catId = 0;
            using (TransactionScope scope = new TransactionScope())
            {
                var cat = new Category()
                {
                    Name = "NEW CATEGORY"
                };
                this.dbContext.Set<Category>().Add(cat);
                this.dbContext.SaveChanges();
                scope.Complete();
                catId = cat.Id;
            }
            Assert.IsTrue(catId != 0);
            var catEntity = this.dbContext.Set<Category>().Find(catId);
            Assert.IsNotNull(catEntity);
        }
    }
}