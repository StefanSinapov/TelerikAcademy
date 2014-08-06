namespace Phonebook.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class AddPhoneTest
    {
        private IPhonebookRepository repository;

        [TestInitialize]
        public void CreateEmptyRepository()
        {
            repository = new PhonebookRepository();
        }

        [TestMethod]
        public void AddingNonExistingEntryShoudReturnTrue()
        {
            bool isNewEntryAdded = repository.AddPhone("Peter", new List<string> { "111", "222" });
            Assert.IsTrue(isNewEntryAdded);
        }

        [TestMethod]
        public void AddingExistingEntryShoudReturnFalse()
        {
            repository.AddPhone("Peter", new List<string> { "333" });
            bool isNewEntryAdded = repository.AddPhone("Peter", new List<string> { "111", "222" });
            Assert.IsFalse(isNewEntryAdded);
        }

        [TestMethod]
        public void AddingExistingEntryWithDiffLetterCaseShoudReturnFalse()
        {
            this.repository.AddPhone("Peter", new List<string> { "123", "234" });
            bool isNewEntryAdded = this.repository.AddPhone("peteR", new List<string> { "345" });
            Assert.IsFalse(isNewEntryAdded);
        }

        [TestMethod]
        public void AddPhoneShouldMergePhoneNumbers()
        {
            this.repository.AddPhone("Peter", new List<string> { "111", "222" });
            var isNewEntryAdded = this.repository.AddPhone("Peter", new List<string> { "333" });
            var mergedEntry = this.repository.ListEntries(0, 1).First();
            Assert.IsFalse(isNewEntryAdded);
            Assert.AreEqual(3, mergedEntry.PhoneNumbers.Count);
            Assert.AreEqual("333", mergedEntry.PhoneNumbers.Skip(2).First());
            Assert.AreEqual("Peter", mergedEntry.Name);
        }

        [TestMethod]
        public void AddPhoneShoudMergeAndKeepOnlyUniquePhoneNumbers()
        {
            this.repository.AddPhone("Peter", new List<string> { "111", "222", "333" });
            var isNewEntryAdded = this.repository.AddPhone("Peter", new List<string> { "222", "333", "444" });
            var mergedEntry = this.repository.ListEntries(0, 1).First();
            Assert.IsFalse(isNewEntryAdded);
            Assert.AreEqual(4, mergedEntry.PhoneNumbers.Count);
            Assert.AreEqual("333", mergedEntry.PhoneNumbers.Skip(2).First());
            Assert.AreEqual("444", mergedEntry.PhoneNumbers.Skip(3).First());
            Assert.AreEqual("Peter", mergedEntry.Name);
        }

        [TestMethod]
        public void AddingPhoneNumbersToEntrisWithDifferentNameShoudListAllSortedByName()
        {
            this.repository.AddPhone("Peter", new List<string> {"111", "222"});
            this.repository.AddPhone("Alex", new List<string> { "222", "444" });
            this.repository.AddPhone("George", new List<string> { "555", "666" });
            var entries = this.repository.ListEntries(0, 3);
            Assert.AreEqual(3, entries.Count());
            Assert.AreEqual("Alex", entries.First().Name);
            Assert.AreEqual("George", entries.Skip(1).First().Name);
            Assert.AreEqual("Peter", entries.Skip(2).First().Name);
        }

        [TestMethod]
        public void AddPhonesAndThenWhenChangePhoneShoudMergeAndDuplicates()
        {
            this.repository.AddPhone("Peter", new List<string> { "111", "222" });
            this.repository.AddPhone("Alex", new List<string> { "222", "444" });
            this.repository.AddPhone("George", new List<string> { "555", "666" });
            this.repository.ChangePhone("222", "999");
            var entries = this.repository.ListEntries(0, 3);

            Assert.AreEqual(2, entries.Count(e => e.PhoneNumbers.Contains("999")));
            Assert.AreEqual(1, entries.Count(e => e.PhoneNumbers.Contains("111")));
            Assert.AreEqual(0, entries.Count(e => e.PhoneNumbers.Contains("222")));
            Assert.AreEqual(1, entries.Count(e => e.Name.Equals("Peter")));
            Assert.AreEqual(1, entries.Count(e => e.Name.Equals("Alex")));
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void AddPhoneWithEmptyNameShoudThrowArgumentException()
        {
            this.repository.AddPhone("", new List<string> {"111"});
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddPhoneWithNullNameShoudThrowArgumentException()
        {
            this.repository.AddPhone(null, new List<string> { "111" });
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void AddPhoneWithNullNumbersShoudThrowArgumentException()
        {
            this.repository.AddPhone("Peter", null);
        }

    }
}
