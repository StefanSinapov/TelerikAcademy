/*
 * 03. Write a program that reads a sequence 
 * of integers (List<int>) ending with an empty line 
 * and sorts them in an increasing order.
 */
namespace _03.Sort_Sequence_of_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SortSequenceOfNumbers
    {
        static void Main()
        {
            var numbers = ReadSequenceFromConsole<int>().ToList();

            numbers.Sort();

            Console.WriteLine("Sorted numbers: {0}", string.Join(", ", numbers));
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
