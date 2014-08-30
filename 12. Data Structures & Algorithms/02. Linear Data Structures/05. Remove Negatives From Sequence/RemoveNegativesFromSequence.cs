/*
 * 5. Write a program that removes from given
 * sequence all negative numbers.
 */
namespace _05.Remove_Negatives_From_Sequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RemoveNegativesFromSequence
    {
        static void Main()
        {
            var numbers = ReadSequenceFromConsole<int>().ToList();
            var positiveNumbers = numbers.Where(n => n >= 0);
            Console.WriteLine("Only positive numbers: {0}", string.Join(", ", positiveNumbers));
        }

        public static IEnumerable<T> ReadSequenceFromConsole<T>() where T : IComparable
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
