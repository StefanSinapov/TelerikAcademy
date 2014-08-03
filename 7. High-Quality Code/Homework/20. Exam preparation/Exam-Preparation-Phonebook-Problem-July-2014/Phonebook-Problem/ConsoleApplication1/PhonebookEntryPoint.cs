using Phonebook.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace Phonebook
{
    class PhonebookEntryPoint
    {
        static void Main()
        {
            IPhonebookRepository repository = new PhonebookRepository();
            IPhoneNumberConverter converter = new PhoneNumberConverter();
            IPrinter printer = new PrinterWithStringBuilder();
            IPhonebookCommand command;
            ICommandBuilder commandBuilder = new CommandBuilderWithLazyLoading();

            while (true)
            {
                string userInputLine = Console.ReadLine();
                if (userInputLine == "End" || userInputLine == null)
                {
                    break;
                }

                int indexOfFirstBracket = userInputLine.IndexOf('(');
                if (indexOfFirstBracket == -1)
                {
                    throw new Exception("Invalid command format");
                }

                string name = userInputLine.Substring(0, indexOfFirstBracket);
                if (!userInputLine.EndsWith(")"))
                {
                    throw new Exception("Invalid command format");
                }
                string argumentsAsString = userInputLine.Substring(indexOfFirstBracket + 1, userInputLine.Length - indexOfFirstBracket - 2);
                string[] arguments = argumentsAsString.Split(',');

                for (int j = 0; j < arguments.Length; j++)
                {
                    arguments[j] = arguments[j].Trim();
                }

                command = commandBuilder.GetCommand(name, arguments);
                command.Execute(arguments, repository, converter, printer);

            }
            Console.Write(printer.getAllAsString());
        }
    }

    public class PhoneEntry : IComparable<PhoneEntry>
    {
        private string name;
        private string nameInLowerCase;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                this.nameInLowerCase = value.ToLowerInvariant();
            }
        }

        public SortedSet<string> PhoneNumbers;

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append('[');
            result.Append(this.Name);
            bool isFirstNumber = true;

            foreach (var phone in this.PhoneNumbers)
            {
                if (isFirstNumber)
                {
                    result.Append(": ");
                    isFirstNumber = false;
                }
                else
                {
                    result.Append(", ");
                }
                result.Append(phone);
            }

            result.Append(']');
            return result.ToString();
        }

        public int CompareTo(PhoneEntry other)
        {
            return this.nameInLowerCase.CompareTo(other.nameInLowerCase);
        }
    }


    class PhonebookRepository : IPhonebookRepository
    {
        private OrderedSet<PhoneEntry> sorted = new OrderedSet<PhoneEntry>();
        private Dictionary<string, PhoneEntry> dict = new Dictionary<string, PhoneEntry>();
        private MultiDictionary<string, PhoneEntry> multidict = new MultiDictionary<string, PhoneEntry>(false);

        public bool AddPhone(string name, IEnumerable<string> nums)
        {
            string nameInLowerCase = name.ToLowerInvariant();
            PhoneEntry entry;
            bool flag = !this.dict.TryGetValue(nameInLowerCase, out entry);
            if (flag)
            {
                entry = new PhoneEntry();
                entry.Name = name;
                entry.PhoneNumbers = new SortedSet<string>();
                this.dict.Add(nameInLowerCase, entry);
                this.sorted.Add(entry);
            }

            foreach (var num in nums)
            {
                this.multidict.Add(num, entry);
            }

            entry.PhoneNumbers.UnionWith(nums);
            return flag;
        }

        public int ChangePhone(string oldent, string newent)
        {
            var found = this.multidict[oldent].ToList();
            foreach (var entry in found)
            {
                entry.PhoneNumbers.Remove(oldent);
                this.multidict.Remove(oldent, entry);
                entry.PhoneNumbers.Add(newent); this.multidict.Add(newent, entry);
            }

            return found.Count;
        }

        public PhoneEntry[] ListEntries(int first, int num)
        {
            if (first < 0 || first + num > this.dict.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            PhoneEntry[] list = new PhoneEntry[num];
            for (int i = first; i <= first + num - 1; i++)
            {
                PhoneEntry entry = this.sorted[i];
                list[i - first] = entry;
            }

            return list;
        }
    }
}
