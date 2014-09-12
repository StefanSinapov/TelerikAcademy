namespace Phonebook.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class ChangePhoneTest
    {
        private IPhonebookRepository repository;

        [TestInitialize]
        public void CreateEmptyRepository()
        {
            repository = new PhonebookRepository();
        }

        [TestMethod]
        public void ChangeExistingPhoneNumberShouldRemoveOldAndAddNewPhoneNumber()
        {
            this.repository.AddPhone("Peter", new List<string> { "111", "222" });
            var matchedPhoneEntries = this.repository.ChangePhone("111", "333");
            var entries = this.repository.ListEntries(0, 1);

            Assert.AreEqual(1, matchedPhoneEntries);
            Assert.AreEqual(2, entries.First().PhoneNumbers.Count);
            Assert.IsTrue(entries.First().PhoneNumbers.Contains("333"));
            Assert.IsFalse(entries.First().PhoneNumbers.Contains("111"));
        }

        [TestMethod]
        public void ChangeNonExistingPhoneNumbersShouldNotTakeEnyEffect()
        {
            this.repository.AddPhone("Peter", new List<string> { "111", "222" });
            var matchedPhoneEntries = this.repository.ChangePhone("555", "333");
            var entry = this.repository.ListEntries(0, 1).First();

            Assert.AreEqual(0, matchedPhoneEntries);
            Assert.AreEqual(2, entry.PhoneNumbers.Count);
            Assert.IsFalse(entry.PhoneNumbers.Contains("333"));
            Assert.IsTrue(entry.PhoneNumbers.Contains("111"));
            Assert.IsTrue(entry.PhoneNumbers.Contains("222"));
        }

        [TestMethod]
        public void ChangeSharedPhoneNumbersShoudTakeEffectInAll()
        {
            this.repository.AddPhone("Peter", new List<string> { "111", "222" });
            this.repository.AddPhone("Alex", new List<string> { "333", "222" });
            this.repository.AddPhone("George", new List<string> { "444", "333" });
            var matchedPhoneEntries = this.repository.ChangePhone("222", "666");
            var entries = this.repository.ListEntries(0, 3);

            Assert.AreEqual(2, matchedPhoneEntries);
            Assert.IsFalse(entries.Any(e => e.PhoneNumbers.Contains("222")));
            Assert.IsTrue(entries.First(e => e.Name == "Alex").PhoneNumbers.Contains("666"));
            Assert.IsFalse(entries.First(e => e.Name == "Alex").PhoneNumbers.Contains("222"));
            Assert.IsTrue(entries.First(e => e.Name == "Peter").PhoneNumbers.Contains("666"));
            Assert.IsFalse(entries.First(e => e.Name == "Peter").PhoneNumbers.Contains("222"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangePhoneOnNullOldPhoneNumberShouldThrowException()
        {
            this.repository.ChangePhone(null, "111");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangePhoneOnEmptyOldPhoneNumberShouldThrowException()
        {
            this.repository.ChangePhone(null, "111");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangePhoneOnNullNewPhoneNumberShouldThrowException()
        {
            this.repository.ChangePhone("", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangePhoneOnEmptyNewPhoneNumberShouldThrowException()
        {
            this.repository.ChangePhone("", null);
        }
    }
}
