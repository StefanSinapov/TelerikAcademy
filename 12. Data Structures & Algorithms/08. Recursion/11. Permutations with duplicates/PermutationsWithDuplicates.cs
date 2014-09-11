﻿/*
 * 11. * Write a program to generate all permutations with repetitions of given multi-set. 
 * 
 * For example the multi-set {1, 3, 5, 5} has the following 12 unique permutations:
 * 
 *  { 1, 3, 5, 5 }	{ 1, 5, 3, 5 }
 *  { 1, 5, 5, 3 }	{ 3, 1, 5, 5 }
 *  { 3, 5, 1, 5 }	{ 3, 5, 5, 1 }
 *  { 5, 1, 3, 5 }	{ 5, 1, 5, 3 }
 *  { 5, 3, 1, 5 }	{ 5, 3, 5, 1 }
 *  { 5, 5, 1, 3 }	{ 5, 5, 3, 1 }
 *  
 * Ensure your program efficiently avoids duplicated permutations. 
 * Test it with { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }.
 */

namespace _11.Permutations_with_duplicates
{
    using System;
    using System.Collections.Generic;

    public class PermutationsWithDuplicates
    {
        //*
        static readonly ISet<string> UniquePermutations = new SortedSet<string>();
        /*/
        static readonly HashSet<string> uniquePermutations = new HashSet<string>(); // faster
        //*/

        
        static readonly int[] Elements = { 1, 3, 5, 5 };

        /*
        static readonly int[] Elements = { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
        */

        public static void Main()
        {
            Permutations(Elements.Length);
            PrintUniquePermutations();
        }

        private static void Permutations(int depth)
        {
            if (depth == 0)
            {
                UniquePermutations.Add(string.Join(" ", Elements));
                return;
            }

            Permutations(depth - 1);

            for (int i = 0; i < depth - 1; i++)
            {
                if (Elements[i] != Elements[depth - 1])
                {
                    Swap(ref Elements[i], ref Elements[depth - 1]);
                    Permutations(depth - 1);
                    Swap(ref Elements[i], ref Elements[depth - 1]);
                }
            }
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            T swap = a;
            a = b;
            b = swap;
        }

        private static void PrintUniquePermutations()
        {
            foreach (var permutation in UniquePermutations)
            {
                Console.WriteLine(permutation);
            }

            Console.WriteLine("\nTotal unique permutations: {0}\n", UniquePermutations.Count);
        }
    }
}