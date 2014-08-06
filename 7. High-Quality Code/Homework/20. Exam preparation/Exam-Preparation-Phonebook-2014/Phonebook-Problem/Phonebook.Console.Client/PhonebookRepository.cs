namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class PhonebookRepository : IPhonebookRepository
    {
        private readonly OrderedSet<PhoneEntry> sortedEntries = new OrderedSet<PhoneEntry>();
        private readonly Dictionary<string, PhoneEntry> dict = new Dictionary<string, PhoneEntry>();
        private readonly MultiDictionary<string, PhoneEntry> multidict = new MultiDictionary<string, PhoneEntry>(false);

        public bool AddPhone(string name, IEnumerable<string> phoneNumbers)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Phone entry name cannot be null or empty.");
            }

            if (phoneNumbers == null)
            {
                throw new NullReferenceException("Phone numbers to add to phone entry cannot be null.");
            }

            string nameInLowerCase = name.ToLowerInvariant();
            PhoneEntry entry;
            bool isEntyExists = !this.dict.TryGetValue(nameInLowerCase, out entry);
            if (isEntyExists)
            {
                entry = new PhoneEntry
                {
                    Name = name,
                    PhoneNumbers = new SortedSet<string>()
                };
                this.dict.Add(nameInLowerCase, entry);
                this.sortedEntries.Add(entry);
            }

            var numbersAsList = phoneNumbers as IList<string> ?? phoneNumbers.ToList();
            foreach (var num in numbersAsList)
            {
                this.multidict.Add(num, entry);
            }

            entry.PhoneNumbers.UnionWith(numbersAsList);
            return isEntyExists;
        }

        public int ChangePhone(string oldPhoneNumber, string newPhoneNumber)
        {
            if (string.IsNullOrEmpty(oldPhoneNumber) || string.IsNullOrEmpty(newPhoneNumber))
            {
                throw new ArgumentException("Phone numbers cannot be null or empty.");
            }

            var found = this.multidict[oldPhoneNumber].ToList();
            foreach (var entry in found)
            {
                entry.PhoneNumbers.Remove(oldPhoneNumber);
                this.multidict.Remove(oldPhoneNumber, entry);
                entry.PhoneNumbers.Add(newPhoneNumber);
                this.multidict.Add(newPhoneNumber, entry);
            }

            return found.Count;
        }

        public IEnumerable<PhoneEntry> ListEntries(int startIndex, int count)
        {
            if (startIndex < 0 || count <= 0 || startIndex + count > this.dict.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            var listedPhoneEntries = this.sortedEntries.Skip(startIndex).Take(count);
            return listedPhoneEntries;
        }
    }
}