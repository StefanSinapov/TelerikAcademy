/*
 * 4. Write a method that finds the longest 
 * subsequence of equal numbers in given List<int> and 
 * returns the result as new List<int>. 
 * Write a program to test whether the method works correctly.
 */

namespace _04.Longest_Subsequence_of_Equels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LongestSubsequenceOfEquels
    {
        static void Main()
        {
            List<int> numbers = ReadSequenceFromConsole<int>().ToList();
            var longestSequence = FindLongestSequence(numbers);

            Console.WriteLine("Longest sequence of elements is: {0}", string.Join(", ", longestSequence));

            // Test in - LinearDataStructures.Tests
        }

        private static List<int> FindLongestSequence(IList<int> numbers)
        {
            int bestOccures = 1;
            int currentOccures = 1;
            int bestElement = numbers[0];
            int previousElement = numbers[0];

            for (int i = 1; i < numbers.Count; i++)
            {
                int currentElement = numbers[i];

                if (currentElement == previousElement)
                {
                    currentOccures++;

                    if (currentOccures > bestOccures)
                    {
                        bestOccures = currentOccures;
                        bestElement = currentElement;
                    }
                    
                }
                else
                {
                    currentOccures = 1;
                    previousElement = currentElement;
                }
            }

            return Enumerable.Repeat(bestElement, bestOccures).ToList();
        }

        private static IEnumerable<T> ReadSequenceFromConsole<T>() where T : IComparable
        {
            var numbers = new List<T>();
            string input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                T number = (T)Convert.ChangeType(input, typeof(T));
                numbers.Add(number);

                input = Console.ReadLine();
            }

            return numbers;
        }
    }
}
