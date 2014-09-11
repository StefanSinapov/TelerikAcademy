using System;
using System.Collections.Generic;

class SubSetSums
{
	static int[] arr = { 5, 5, 15, 20, 1 };
	static int sum = 26;
	static bool[,] f = new bool[arr.Length, sum + 1];
	static bool[,] isCalculated = new bool[arr.Length, sum + 1];

	static void Main()
	{
		bool possibleSum = CalcF(arr.Length - 1, sum);
		if (possibleSum)
		{
			PrintSubset(arr.Length - 1, sum);
		}
		else
		{
			Console.WriteLine("Not possible!");
		}
	}

	static bool CalcF(int i, int sum)
	{
		if (sum < 0 || i < 0)
		{
			return false;
		}

		if (!isCalculated[i, sum])
		{
			f[i, sum] =
				(arr[i] == sum) ||
				CalcF(i - 1, sum) ||
				CalcF(i - 1, sum - arr[i]);
			isCalculated[i, sum] = true;
		}

		return f[i, sum];
	}

	private static void PrintSubset(int i, int sum)
	{
		Console.Write(sum + " = ");
		List<int> nums = new List<int>();
		while (true)
		{
			if (arr[i] == sum)
			{
				nums.Add(arr[i]);
				break;
			}
			else if (CalcF(i - 1, sum - arr[i]))
			{
				// Take arr[k]
				nums.Add(arr[i]);
				sum = sum - arr[i];
				i = i - 1;
			}
			else if (CalcF(i - 1, sum))
			{
				// Skip arr[k]
				i = i - 1;
			}
		}
		Console.WriteLine(string.Join(" + ", nums));
	}
}
