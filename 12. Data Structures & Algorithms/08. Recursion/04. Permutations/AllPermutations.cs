/*
 * 4. Write a recursive program for generating and printing all 
 * permutations of the numbers 1, 2, ..., n for given integer number n.
    - Example: n = 3 -> { 1, 2, 3 }, { 1, 3, 2 }, { 2, 1, 3 }, { 2, 3, 1 }, { 3, 1, 2 },{ 3, 2, 1 }
 */
namespace _04.Permutations
{
    using System;

    class AllPermutations
    {
        private static int[] permutations;
        private static bool[] used;
        private static int numberOfElements;

        static void Main()
        {
            numberOfElements = int.Parse(Console.ReadLine());
            permutations = new int[numberOfElements];
            used = new bool[numberOfElements];

            Permutation(0);
        }

        private static void Permutation(int currentElement)
        {
            if (currentElement >= numberOfElements)
            {
                Print();
                return;
            }

            for (int i = 0; i < numberOfElements; i++)
            {
                if (used[i])
                {
                    continue;
                }

                used[i] = true;
                permutations[currentElement] = i + 1;
                Permutation(currentElement + 1);
                used[i] = false;
            }
        }

        private static void Print()
        {
            Console.WriteLine("({0})", string.Join(", ", permutations));
        }
    }
}
