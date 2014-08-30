/*
 * 8. The majorant of an array of size N is a value that 
 * occurs in it at least N/2 + 1 times. 
 * Write a program to find the majorant of given array (if exists). 
	- Example: {2, 2, 3, 3, 2, 3, 4, 3, 3} ? 3
 */
namespace _08.Majorant_Of_Array
{
    using System;
    using System.Collections.Generic;

    class MajorantOfArray
    {
        static void Main()
        {
            var numbers = new Dictionary<int, int>();
            var arrayLenght = 0;
            string input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {
                int number = int.Parse(input);
                if (!numbers.ContainsKey(number))
                {
                    numbers[number] = 0;
                }
                numbers[number]++;
                arrayLenght++;

                input = Console.ReadLine();
            }

            var majorant = FindMajorant(arrayLenght, numbers);

            PrintResult(majorant);
            
        }

        private static int? FindMajorant(int arrayLenght, Dictionary<int, int> numbers)
        {
            var majorantFormulaResult = arrayLenght/2 + 1;

            int? majorant = null;
            foreach (var number in numbers)
            {
                if (number.Value >= majorantFormulaResult)
                {
                    majorant = number.Key;
                }
            }
            return majorant;
        }

        private static void PrintResult(int? majorant)
        {
            if (majorant == null)
            {
                Console.WriteLine("This sequence has no majorant");
            }
            else
            {
                Console.WriteLine("Majorant is {0}", majorant);
            }
        }
    }
}
