/*
 2.Write a program that extracts from a given sequence 
 * of strings all elements that present in it odd number of times. 
 * Example:
	{C#, SQL, PHP, PHP, SQL, SQL } -> {C#, SQL}
 */
namespace _02.Odd_Number_of_Times
{
    using System;
    using System.Collections.Generic;

    class OddNumberOfTimes
    {
        static void Main()
        {
            string[] words = {"C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            var dict = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!dict.ContainsKey(word))
                {
                    dict.Add(word, 0);
                }
                dict[word]++;
            }

            var result = new HashSet<string>();
            foreach (var pair in dict)
            {
                if (pair.Value%2 != 0)
                {
                    result.Add(pair.Key);
                }
            }

            Console.WriteLine("{0}", string.Join(", ", result));
        }
    }
}
