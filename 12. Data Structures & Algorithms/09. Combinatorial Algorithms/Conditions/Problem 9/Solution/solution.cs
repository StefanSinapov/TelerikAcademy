using System;

class BinaryTrees
{
	static void Main()
	{
		string ballsStr = Console.ReadLine();
		char[] balls = ballsStr.ToCharArray();

		long treesCount = CalculateBinaryTreesCount(balls.Length);
		//Console.WriteLine("Trees: " + treesCount);

		long coloringCount = CountColoring(balls);
		//Console.WriteLine("Colors: " + coloringCount);

		// Use C# keyword "checked" to ensure integer overflow is not possible
		checked
		{
			decimal totalTrees = (decimal)treesCount * coloringCount;
			Console.WriteLine(totalTrees);
		}
	}

	private static long CalculateBinaryTreesCount(int n)
	{
		// Dynamic programming (calculate a recurrence formula): 
		// trees[0] = 1;
		// trees[n] = sum( trees[i] * trees[n-i-1] ) for each i in [0..n-1]
		// i = number of nodes in the left subtree
		// n-i-1 = number of nodes in the right subtree

		long[] treesCount = new long[n + 1];
		treesCount[0] = 1;
		for (int nodes = 1; nodes <= n; nodes++)
		{
			treesCount[nodes] = 0;
			for (int i = 0; i < nodes; i++)
			{
				int leftSubtreeSize = i;
				int rightSubtreeSize = nodes - i - 1;
				// Use C# keyword "checked" to ensure integer overflow is not possible
				checked
				{
					treesCount[nodes] +=
					treesCount[leftSubtreeSize] * treesCount[rightSubtreeSize];
				}
			}
		}
		return treesCount[n];
	}

	private static long CountColoring(char[] balls)
	{
		// We calculate directly the formula n! / (c1! * c2! * ... ck!)
		// where c1, c2, .. ck are the number of the balls for each color

		int n = balls.Length;
		long result = Factorial(n);

		int[] ballCounts = new int['Z' + 1];
		foreach (var ball in balls)
		{
			ballCounts[ball]++;
		}
		for (int i = 'A'; i <= 'Z'; i++)
		{
			int ballsOfCertainColor = ballCounts[i];
			long factorial = Factorial(ballsOfCertainColor);
			result /= factorial;
		}

		return result;
	}

	private static long Factorial(int n)
	{
		// Use C# keyword "checked" to ensure integer overflow is not possible
		checked
		{
			long result = 1;
			for (int i = 2; i <= n; i++)
			{
				result *= i;
			}
			return result;
		}
	}
}
