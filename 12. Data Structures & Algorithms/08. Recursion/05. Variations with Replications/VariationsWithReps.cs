/*
 * 5. Write a recursive program for generating and printing 
 * all ordered k-element subsets from n-element set 
 * (variations V<sup>k</sup><sub>n</sub>)
    - Example: n = 3, k = 2, set = { hi, a, b } -> 
 * (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)`
 */
namespace _05.Variations_with_Replications
{
    using System;

    class VariationsWithReps
    {
        private static readonly string[] elements = { "hi", "a", "b" };
        private static int[] variations;
        private static int N;
        private const int K = 2;

        static void Main()
        {
            N = elements.Length;
            variations = new int[N];

            Variations(0);
        }

        private static void Variations(int currentElement)
        {
            if (currentElement >= K)
            {
                Print();
                return;
            }

            for (int i = 0; i < N; i++)
            {
                variations[currentElement] = i;
                Variations(currentElement + 1);
            }
        }

        private static void Print()
        {
            for (int i = 0; i < K; i++)
            {
                Console.Write(elements[variations[i]] + " ");
            }

            Console.WriteLine();
        }
    }
}
