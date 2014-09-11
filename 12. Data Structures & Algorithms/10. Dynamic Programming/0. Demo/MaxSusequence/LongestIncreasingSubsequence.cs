using System;
using System.Collections.Generic;

class LongestIncreasingSubsequence
{
	const int NO_PREVIOUS = -1;

	static void Main()
	{
		int[] arr = { 3, 4, 8, 1, 2, 4, 32, 6, 2, 5, 33, 4, 38, 22 };
		int[] lis = new int[arr.Length];
		int[] back = new int[arr.Length];

		for (int i = 0; i < arr.Length; i++)
		{
			back[i] = NO_PREVIOUS;
		}

		int bestIndex = CalculateLongestIncreasingSubsequence(arr, lis, back);

		Console.WriteLine("arr = " + String.Join(", ", arr));
		Console.WriteLine("lis = " + String.Join(", ", lis));
		Console.WriteLine("back = " + String.Join(", ", back));

		PrintLongestIncreasingSubsequence(arr, back, bestIndex);
	}

	private static int CalculateLongestIncreasingSubsequence(int[] arr, int[] lis, int[] back)
	{
		int bestF = 0;
		int bestIndex = 0;
		for (int i = 0; i < arr.Length; i++)
		{
			lis[i] = 1;
			for (int k = 0; k <= i - 1; k++)
			{
				if (arr[k] < arr[i])
				{
					if (lis[k] + 1 > lis[i])
					{
						lis[i] = lis[k] + 1;
						back[i] = k;
						if (lis[i] > bestF)
						{
							bestF = lis[i];
							bestIndex = i;
						}
					}
				}
			}
		}
		return bestIndex;
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

