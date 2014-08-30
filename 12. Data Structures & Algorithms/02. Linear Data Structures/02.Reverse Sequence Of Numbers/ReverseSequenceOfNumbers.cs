/*
 * Write a program that reads N integers from the console 
 * and reverses them using a stack. Use the Stack<int> class.
 */
namespace _02.Reverse_Sequence_Of_Numbers
{
    using System;
    using System.Collections.Generic;

    class ReverseSequenceOfNumbers
    {
        static void Main()
        {
            var numbers = new Stack<int>();

            var input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {
                int number = int.Parse(input);
                numbers.Push(number);

                input = Console.ReadLine();
            }

            Console.WriteLine("Numbers in revert order:");
            while(numbers.Count != 0)
            {
                Console.WriteLine("{0}",numbers.Pop());
            }
        }
    }
}
