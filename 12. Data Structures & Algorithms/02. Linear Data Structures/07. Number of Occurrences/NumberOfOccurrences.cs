/*
 * 7. Write a program that finds in given array of integers 
 * (all belonging to the range [0..1000]) how many times each of them occurs.
	- Example: 
		- array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
		- 2 - 2 times
		- 3 - 4 times
		- 4 - 3 times
 */
namespace _07.Number_of_Occurrences
{
    using System;
    using System.Collections.Generic;

    class NumberOfOccurrences
    {
        static void Main()
        {
            var numbers = ReadInput();
            PrintResult(numbers);
        }

        private static Dictionary<int, int> ReadInput()
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
            return numbers;
        }

        private static void PrintResult(Dictionary<int, int> numbers)
        {
            Console.WriteLine("Number of occurs:");
            foreach (var number in numbers)
            {
                Console.WriteLine("     {0} - {1} times", number.Key, number.Value);
            }
        }
    }
}
