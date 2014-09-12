/* * We are given an array of integers and a number S. 
 * Write a program to find if there exists a subset of 
 * the elements of the array that has a sum S. Example:
	arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14  yes (1+2+5+6)
 */

using System;

class SubSetSum
{
	static void Main()
	{
		Console.WriteLine("Enter the wanted sum of the subsets:");
		long wantedSum = long.Parse(Console.ReadLine());
		Console.WriteLine("Enter the number of elements:");
		long numberOfElements = long.Parse(Console.ReadLine());
		long[] elements = new long[numberOfElements];
		int counter = 0;
		string subset = "";
		for (int i = 0; i < elements.Length; i++)
		{
			Console.WriteLine("Enter element № {0}", i + 1);
			elements[i] = long.Parse(Console.ReadLine());
		}
		int maxSubsets = (int)Math.Pow(2, numberOfElements) - 1;
		for (int i = 1; i <= maxSubsets; i++)
		{
			subset = "";
			long checkingSum = 0;
			for (int j = 0; j <= numberOfElements; j++)
			{
				int mask = 1 << j;
				int nAndMask = i & mask;
				int bit = nAndMask >> j;
				if (bit == 1)
				{
					checkingSum = checkingSum + elements[j];
					subset = subset + " " + elements[j];
				}
			}
			if (checkingSum == wantedSum)
			{
				Console.WriteLine("Number of subest that have the sum of {0}", wantedSum);
				counter++;
				Console.WriteLine("This subset has a sum of {0} : {1} ", wantedSum, subset);
			}
		}
		Console.WriteLine(counter);
	}
}