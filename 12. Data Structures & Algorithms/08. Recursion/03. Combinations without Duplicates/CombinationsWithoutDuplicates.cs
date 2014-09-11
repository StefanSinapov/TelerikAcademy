/*
 * 3. Modify the previous program to skip duplicates:
    - Example: n = 4, k = 2 -> (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)
 */
namespace _03.Combinations_without_Duplicates
{
    using System;

    class CombinationsWithoutDuplicates
    {
        private static int[] combinations;
        private static int elementsSet;
        private static int elementsCount;

        static void Main()
        {
            elementsSet = int.Parse(Console.ReadLine());
            elementsCount = int.Parse(Console.ReadLine());
            combinations = new int[elementsCount];

            Combinations(0, 0, false);
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
                combinations[currentLoop] = i + 1;
                Combinations(withReps ? i : i + 1, currentLoop + 1, withReps);
            }
        }

        private static void Print()
        {
            Console.WriteLine("({0})", string.Join(", ", combinations));
        }
    }
}
