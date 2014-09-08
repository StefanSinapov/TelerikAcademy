/*
 * 1. Write a program that counts in a given array of double 
 * values the number of occurrences of each value. 
 * Use Dictionary<TKey,TValue>.
	Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
	-2.5 -> 2 times
	3 -> 4 times
	4 -> 3 times
 */
namespace _01.Number_Of_Occurrences
{
    using System;
    using System.Collections.Generic;

    class NumberOfAccurrences
    {
        static void Main()
        {
            double[] array = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            var dict = new Dictionary<double, int>();

            CountOccurrences(array, dict);
            PrintResult(dict);
        }

        private static void PrintResult(Dictionary<double, int> dict)
        {
            foreach (var pair in dict)
            {
                Console.WriteLine("{0} -> {1} times.", pair.Key, pair.Value);
            }
        }

        private static void CountOccurrences(IEnumerable<double> array, Dictionary<double, int> dict)
        {
            foreach (var number in array)
            {
                if (!dict.ContainsKey(number))
                {
                    dict.Add(number, 0);
                }
                dict[number]++;
            }
        }
    }
}
