/*
 * 6. Write a program that removes from given 
 * sequence all numbers that occur odd number of times. 
	- Example: {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} -> {5, 3, 3, 5}
 */
namespace _06.Remove_Odd_Occures
{
    using System;
    using System.Collections.Generic;

    class RemoveOddOccur
    {
        static void Main()
        {
            var numbers = new Dictionary<int, int>();
            string input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {
                int number = int.Parse(input);
                if (!numbers.ContainsKey(number))
                {
                    numbers[number] = 0;
                }
                numbers[number]++;

                input = Console.ReadLine();
            }

            var oddNumbers = FindOddОccurrences(numbers);

            Console.WriteLine("Numbers that occurs odd number of times: {0}", string.Join(", ", oddNumbers));

        }

        private static IEnumerable<int> FindOddОccurrences(Dictionary<int, int> numbers)
        {
            var oddNumbers = new List<int>();
            foreach (var number in numbers)
            {
                if (number.Value%2 == 0)
                {
                    oddNumbers.Add(number.Key);
                }
            }
            return oddNumbers;
        }

        public static IEnumerable<T> ReadSequenceFromConsole<T>() where T : IComparable
        {
            var numbers = new List<T>();
            string input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                var number = (T)Convert.ChangeType(input, typeof(T));
                numbers.Add(number);

                input = Console.ReadLine();
            }

            return numbers;
        }
    }
}
