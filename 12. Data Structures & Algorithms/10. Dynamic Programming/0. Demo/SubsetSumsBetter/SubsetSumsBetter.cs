using System;
using System.Collections.Generic;
using System.Linq;

class SubsetSumsBetter
{
	static void Main(string[] args)
	{
		int[] arr = { 2, 5, 10 };
		int targetSum = 50;

		bool[] possible = CalcPossibleSums(arr, targetSum);

		// Print subset
		if (possible[targetSum])
		{
			PrintSubset(arr, targetSum, possible);
		}
		else
		{
			Console.WriteLine("Not possible");
		}
	}

	private static bool[] CalcPossibleSums(int[] arr, int targetSum)
	{
		bool[] possible = new bool[targetSum + 1];
		possible[0] = true;
		for (int sum = 0; sum < possible.Length; sum++)
		{
			if (possible[sum])
			{
				for (int i = 0; i < arr.Length; i++)
				{
					int newSum = sum + arr[i];
					if (newSum <= targetSum)
					{
						possible[newSum] = true;
					}
				}
			}
		}
		return possible;
	}

	private static void PrintSubset(int[] arr, int targetSum, bool[] possible)
	{
		Console.Write(targetSum + " = ");
		List<int> nums = new List<int>();
		while (targetSum > 0)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				int newSum = targetSum - arr[i];
				if (newSum >= 0 && possible[newSum])
				{
					targetSum = newSum;
					nums.Add(arr[i]);
				}
			}
		}
		Console.WriteLine(String.Join(" + ", nums));
	}
}
