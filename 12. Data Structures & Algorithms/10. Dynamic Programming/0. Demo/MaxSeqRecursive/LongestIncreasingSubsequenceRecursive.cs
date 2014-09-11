using System;
using System.Collections.Generic;

class LongestIncreasingSubsequenceRecursive
{
	const int NO_PREVIOUS = -1;

	static int[] arr = { 3, 4, 8, 1, 2, 4, 32, 6, 2, 5, 33, 4, 38, 22 };
	static int[] lis = new int[arr.Length];
	static int[] back = new int[arr.Length];

	static void Main()
	{
		for (int i = 0; i < arr.Length; i++)
		{
			back[i] = NO_PREVIOUS;
		}

		for (int i = 0; i < arr.Length; i++)
		{
			CalcLongestIncreasingSubsequence(i);
		}

		Console.WriteLine("arr = " + String.Join(", ", arr));
		Console.WriteLine("lis = " + String.Join(", ", lis));
		Console.WriteLine("back = " + String.Join(", ", back));

		int maxElementIndex = FindMaxElementIndex(arr);

		PrintLongestIncreasingSubsequence(arr, back, maxElementIndex);
	}

	static void CalcLongestIncreasingSubsequence(int k)
	{
		if (lis[k] > 0)
		{
			// memoization
			return;
		}

		lis[k] = 1;
		for (int i = 0; i <= k-1; i++)
		{
			if (arr[i] < arr[k])
			{
				CalcLongestIncreasingSubsequence(i);
				if (lis[i] + 1 > lis[k])
				{
					lis[k] = lis[i] + 1;
					back[k] = i;
				}
			}
		}
	}

	static int FindMaxElementIndex(int[] arr)
	{
		int maxElement = arr[0];
		int maxElementIndex = 0;
		for (int i = 0; i < arr.Length; i++)
		{
			if (arr[i] > maxElement)
			{
				maxElement = arr[i];
				maxElementIndex = i;
			}
		}
		return maxElementIndex;
	}

	static void PrintLongestIncreasingSubsequence(int[] arr, int[] back, int index)
	{
		List<int> lis = new List<int>();
		while (index != NO_PREVIOUS)
		{
			lis.Add(arr[index]);
			index = back[index];
		}
		lis.Reverse();
		Console.WriteLine("subsequence = " + String.Join(" ", lis));
	}
}
