namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class PhonebookRepository : IPhonebookRepository
    {
        private readonly OrderedSet<PhoneEntry> sorted = new OrderedSet<PhoneEntry>();
        private readonly Dictionary<string, PhoneEntry> dict = new Dictionary<string, PhoneEntry>();
        private readonly MultiDictionary<string, PhoneEntry> multidict = new MultiDictionary<string, PhoneEntry>(false);

        public bool AddPhone(string name, IEnumerable<string> numbers)
        {
            string nameInLowerCase = name.ToLowerInvariant();
            PhoneEntry entry;
            bool flag = !this.dict.TryGetValue(nameInLowerCase, out entry);
            if (flag)
            {
                entry = new PhoneEntry
                {
                    Name = name,
                    PhoneNumbers = new SortedSet<string>()
                };
                this.dict.Add(nameInLowerCase, entry);
                this.sorted.Add(entry);
            }

            var phoneNumbers = numbers as IList<string> ?? numbers.ToList();
            foreach (var num in phoneNumbers)
            {
                this.multidict.Add(num, entry);
            }

            entry.PhoneNumbers.UnionWith(phoneNumbers);
            return flag;
        }

        public int ChangePhone(string oldent, string newent)
        {
            var found = this.multidict[oldent].ToList();
            foreach (var entry in found)
            {
                entry.PhoneNumbers.Remove(oldent);
                this.multidict.Remove(oldent, entry);
                entry.PhoneNumbers.Add(newent);
                this.multidict.Add(newent, entry);
            }

            return found.Count;
        }

        public PhoneEntry[] ListEntries(int first, int count)
        {
            if (first < 0 || first + count > this.dict.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            var list = new PhoneEntry[count];
            for (var i = first; i <= first + count - 1; i++)
            {
                var entry = this.sorted[i];
                list[i - first] = entry;
            }

            return list;
        }
    }
}