/* Write a program that reads two
 * integer numbers N and K and an array
 * of N elements from the console. Find
 * in the array those K elements that have maximal sum.
 */
 
using System;
class MaxSumOfGivenElementsInArray
{
	static void Main(string[] args)
	{
		//input
		Console.Write("K= ");
		int k = int.Parse(Console.ReadLine());
		Console.Write("N= ");
		int n = int.Parse(Console.ReadLine());
		int[] array=new int[n];
		Console.WriteLine("Elements of array:");
		for (int i = 0; i < n; i++)
		{
			Console.Write("array [{0}]= ",i);
			array[i] = int.Parse(Console.ReadLine());

		}

		if (k > n)
		{
			Console.WriteLine("Invalid, K>N");
		}
		else
		{
			//find tha sum
			int maxSum = 0;
			for (int i = 0; i < n - k + 1 ; i++)
			{
				int sum = 0;
				for (int j = i; j < i + k; j++)
				{
					sum += array[j];
				}
				if (sum > maxSum)
				{
					maxSum = sum;
				}
			}

			//output
			Console.WriteLine("The maximal sum of {0} elements is: {1}", k, maxSum);
		}
	}
}

