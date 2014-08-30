/*
 * 1. Write a program that reads from the console a sequence 
 * of positive integer numbers. The sequence ends when empty 
 * line is entered. Calculate and print the sum and average 
 * of the elements of the sequence. Keep the sequence in List<int>.
 */
namespace FindSumAndAverageOfSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FindSumAndAverage
    {
        static void Main()
        {
            var numbers = new List<int>();
            
            var input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {
                int number = int.Parse(input);
                numbers.Add(number);

                input = Console.ReadLine();
            }

            var averageValue = numbers.Average();
            var sumOfNumbers = numbers.Sum();

            Console.WriteLine("Average: {0}", averageValue);
            Console.WriteLine("Sum: {0}", sumOfNumbers);
        }
    }
}
