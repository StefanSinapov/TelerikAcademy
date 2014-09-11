/*
 * 6. Write a program for generating and printing all
 * subsets of k strings from given set of strings.
 * 
 * Example: s = {test, rock, fun}, k=2 -> (test rock), (test fun), (rock fun)
 */
namespace _06.Variations_without_Replications
{
    using System;

    class VariationsWitouthReps
    {
        private static readonly string[] Elements = { "test", "rock", "fun" };
        private static int[] variations;
        private static int N;
        private static int K = 2;

        static void Main()
        {
            N = Elements.Length;
            variations = new int[N];

            Variations(0, 0);
        }

        private static void Variations(int start, int depth)
        {
            if (depth >= K)
            {
                Print();
                return;
            }

            for (int i = start; i < N; i++, start++)
            {
                variations[depth] = i;
                Variations(start + 1, depth + 1);
            }
        }

        private static void Print()
        {
            for (int i = 0; i < K; i++)
            {
                Console.Write(Elements[variations[i]] + " ");
            }

            Console.WriteLine();
        }
    }
}
