using System.Collections.Generic;
using System.Linq;

namespace Phonebook.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class ListPhoneTest
    {
        private IPhonebookRepository repository;

        [TestInitialize]
        public void CreateEmptyRepository()
        {
            repository = new PhonebookRepository();
        }

        [TestMethod]
        public void ListSingleExistingEntry()
        {
            this.repository.AddPhone("Peter", new List<string> { "111", "222" });
            var entriesArray = this.repository.ListEntries(0, 1);

            Assert.AreEqual(1, entriesArray.Count());
            Assert.AreEqual("Peter", entriesArray.First().Name);
            Assert.AreEqual(2, entriesArray.First().PhoneNumbers.Count);
            Assert.AreEqual(new List<string> { "111", "222" }, entriesArray.First().PhoneNumbers.ToList());
        }

        [TestMethod]
        public void ListMultipleEntries()
        {
            this.repository.AddPhone("Alex", new List<string> { "222", "333" });
            this.repository.AddPhone("George", new List<string> { "444", "555", "666" });
            this.repository.AddPhone("Peter", new List<string> { "111", "222" });
            var entriesArray = this.repository.ListEntries(0, 3);

            Assert.AreEqual(3, entriesArray.Count());
            Assert.AreEqual("Alex", entriesArray.First().Name);
            Assert.AreEqual(2, entriesArray.First().PhoneNumbers.Count);
            Assert.AreEqual(new List<string> { "444", "555", "666" }, entriesArray.Skip(1).First().PhoneNumbers.ToList());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListEntriesWithNegativeCountShouldThrowException()
        {
            this.repository.AddPhone("John", new List<string> { "111", "222" });
            this.repository.ListEntries(0, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListEntriesWithCountBiggetThanMaxCountShouldThrowException()
        {
            this.repository.AddPhone("John", new List<string> { "111", "222" });
            this.repository.ListEntries(0, int.MaxValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListEntriesWithInvalidIndexAndCountShouldThrowException()
        {
            this.repository.ListEntries(1, 1);
        }
    }
}
