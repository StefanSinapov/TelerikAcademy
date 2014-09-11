/*
 * 1. 1. Write a program based on dynamic programming 
 * to solve the "Knapsack Problem": you are given N products, 
 * each has weight W i and costs C i and a knapsack of capacity M
 * and you want to put inside a subset of the products with highest
 * cost and weight -> M. The numbers N, M, W i and C i are integers
 * in the range [1..500]. 
 * Example: M=10 kg, N=6, products:
	- beer – weight=3, cost=2
	- vodka – weight=8, cost=12
	- cheese – weight=4, cost=5
	- nuts – weight=1, cost=4
	- ham – weight=2, cost=3
	- whiskey – weight=8, cost=13
	|-----------------------|
	|	Optimal Solution	|
	|-----------------------|
	|	nuts + whiskey		|
	|	weight = 9			|
	|	cost = 17			|
	|-----------------------|
 */
namespace _01.Knapsack_Problem
{
    using System;

    class KnapsackProblemDemo
    {
        

        private static string[] products = { "beer", "vodka", "cheese", "nuts", "ham", "whiskey" };
        private static readonly int[] Weights = { 3, 8, 4, 1, 2, 8 };
        private static readonly int[] Costs = { 2, 12, 5, 4, 3, 13 };
        private const int Size = 10;
        private const int NumberOfItems = 6;
        private static readonly int[,] Matrix = new int[2 * Size, 2 * Size];

        static void Main()
        {

            int knapsackSize = Knapsack(NumberOfItems - 1, Size, Weights, Costs);

            Console.WriteLine("Optimal Solution = {0}", knapsackSize);
        }

        

        private static int Knapsack(int index, int size, int[] weights, int[] values)
        {
            int take = 0;

            if (Matrix[index, size] != 0)
            {
                return Matrix[index, size];
            }

            if (index == 0)
            {
                if (weights[0] <= 0)
                {
                    Matrix[index, size] = values[0];
                    return values[0];
                }
                Matrix[index, size] = 0;
                return 0;
            }

            if (weights[index] <= size)
            {
                take = values[index] + Knapsack(index - 1, size - weights[index], weights, values);
            }

            int dontTake = Knapsack(index - 1, size, weights, values);

            Matrix[index, size] = Math.Max(take, dontTake);

            return Matrix[index, size];
        }
    }
}
