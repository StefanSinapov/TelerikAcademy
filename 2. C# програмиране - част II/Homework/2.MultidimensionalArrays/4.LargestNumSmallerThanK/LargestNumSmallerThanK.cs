/*
 * Write a program, that reads from the console an array of N integers and an integer K,
 * sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 
 */
using System;

class LargestNumSmallerThanK
{
	static void Main()
	{
		int[] array = { 3, 36, 3534, 4, 6456, 24, 231, 11, 9, 100000 };
		int k = 7;
		int index = -1;
		Array.Sort(array);
		for (int i = 0; i < array.Length; i++)
		{
			Console.Write("{0}  ", array[i]);
		}
		Console.WriteLine();
		if (k < array[0])
		{
			Console.WriteLine("K is too small!");
		}
		else
		{
			for (int i = k; i >= array[0]; i--)
			{
				index = Array.BinarySearch(array, i);
				if (index > 0)
				{
					break;
				}
			}
			Console.WriteLine("The closest number to {0} is {1} at position {2}", k, array[index], index);
		}

	}
}