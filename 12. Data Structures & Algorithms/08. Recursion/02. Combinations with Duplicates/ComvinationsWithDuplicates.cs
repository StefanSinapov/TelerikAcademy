/*
 * 2. Write a recursive program for generating and printing all the 
 * combinations with duplicates of k elements from n-element set.
    - Example: n = 3, k = 2 -> (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)
 */
namespace _02.Combinations_with_Duplicates
{
    using System;

    class ComvinationsWithDuplicates
    {
        private static int[] combinations;
        private static int elementsSet;
        private static int elementsCount;

        static void Main()
        {
            elementsSet = int.Parse(Console.ReadLine());
            elementsCount = int.Parse(Console.ReadLine());
            combinations = new int[elementsCount];

            Combinations(0);
        }

        private static void Combinations(int startValue, int currentLoop = 0, bool withReps = true)
        {
            if (currentLoop >= elementsCount)
            {
                Print();
                return;
            }

            for (int i = startValue; i < elementsSet; i++)
            {
                combinations[currentLoop] = i+1;
                Combinations(withReps ? i : i + 1, currentLoop + 1, withReps);
            }
        }

        private static void Print()
        {
            Console.WriteLine("({0})", string.Join(", ",combinations));
        }
    }
}
