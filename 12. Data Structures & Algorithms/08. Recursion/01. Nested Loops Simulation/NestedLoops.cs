/*
 * 1. Write a recursive program that simulates the execution
 * of n nested loops from 1 to n. Examples:

    ```
                               1 1 1
                               1 1 2
                               1 1 3
             1 1               1 2 1
    n = 2->  1 2      n = 3 -> ...
             2 1               3 2 3
             2 2               3 3 1
                               3 3 2
                               3 3 3
    ```
 */
namespace _01.Nested_Loops_Simulation
{
    using System;

    class NestedLoops
    {
        static int numberOfLoops;
        static int[] loops;

        static void Main()
        {
            Console.Write("N = ");
            numberOfLoops = int.Parse(Console.ReadLine());

            loops = new int[numberOfLoops];

            LoopSimulator(0);
        }

        private static void LoopSimulator(int currentLoop)
        {
            if (currentLoop == numberOfLoops)
            {
                PrintLoops();
                return;
            }

            for (int counter = 1; counter <= numberOfLoops; counter++)
            {
                loops[currentLoop] = counter;
                LoopSimulator(currentLoop + 1);
            }
        }

        static void PrintLoops()
        {
            for (int i = 0; i < numberOfLoops; i++)
            {
                Console.Write("{0} ", loops[i]);
            }
            Console.WriteLine();
        }
    }
}
