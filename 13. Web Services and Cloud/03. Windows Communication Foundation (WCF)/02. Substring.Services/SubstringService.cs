namespace Substring.Services
{
    using System;

    public class SubstringService : ISubstringService
    {
        public int GetNumberOfSubstrings(string text, string substring)
        {
            int count = 0;

            int index = text.IndexOf(substring, StringComparison.Ordinal);

            while (index != -1)
            {
                count++;
                index = text.IndexOf(substring, index + 1, StringComparison.Ordinal);
            }

            return count;
        }
    }
}