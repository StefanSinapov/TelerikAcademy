using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class PhoneNumberConverter : IPhoneNumberConverter
    {
        private const string DEFAUTH_COUTNRY_CODE = "+359";

        public string Convert(string phoneNumber)
        {
            StringBuilder convertedPhoneNumber = new StringBuilder();

            foreach (char ch in phoneNumber)
            {
                if (char.IsDigit(ch) || (ch == '+'))
                {
                    convertedPhoneNumber.Append(ch);
                }
            }

            if (convertedPhoneNumber.Length >= 2 && convertedPhoneNumber[0] == '0' && convertedPhoneNumber[1] == '0')
            {
                convertedPhoneNumber.Remove(0, 1); convertedPhoneNumber[0] = '+';
            }

            while (convertedPhoneNumber.Length > 0 && convertedPhoneNumber[0] == '0')
            {
                convertedPhoneNumber.Remove(0, 1);
            }

            if (convertedPhoneNumber.Length > 0 && convertedPhoneNumber[0] != '+')
            {
                convertedPhoneNumber.Insert(0, DEFAUTH_COUTNRY_CODE);
            }

            return convertedPhoneNumber.ToString();
        }
    }
}
