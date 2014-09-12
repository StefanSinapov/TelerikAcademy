namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Text;

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

        public SortedSet<string> PhoneNumbers { get; set; }

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
            return string.Compare(this.nameInLowerCase, other.nameInLowerCase, StringComparison.Ordinal);
        }
    }
}