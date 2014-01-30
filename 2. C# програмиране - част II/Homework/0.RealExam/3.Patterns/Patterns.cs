using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class Patterns
{
	static int n;
	static int[,] matrix;
	static bool isPatternFound = false;
	static BigInteger patternSum = int.MinValue;
	static BigInteger diagonalSum = 0;

	static void Main()
	{
		ReadInput();

		//search for pattern
		SearchForPatterns();

		//found diagonal sum
		ValueOfDiagonal();

		if(isPatternFound)
		{
			Console.WriteLine("YES {0}",patternSum);
		}
		else
		{
			Console.WriteLine("NO {0}",diagonalSum);
		}
	}

	static void ValueOfDiagonal()
	{
		for (int i = 0; i < n; i++)
		{
			diagonalSum += matrix[i, i];
		}
	}

	static void SearchForPatterns()
	{
		for (int i = 0; i <= n - 3; i++)
		{
			for (int j = 0; j <= n - 5; j++)
			{
				if (CheckIfPattern(i, j))
				{
					isPatternFound = true;
					BigInteger currentSum = ValueOfPattern(i, j);
					if (currentSum > patternSum)
					{
						patternSum = currentSum;
					}
				}
			}
		}

	}

	private static BigInteger ValueOfPattern(int i, int j)
	{
		int A = matrix[i, j];
		int B = matrix[i, j + 1];
		int C = matrix[i, j + 2];
		int D = matrix[i + 1, j + 2];
		int F = matrix[i + 2, j + 2];
		int E = matrix[i + 2, j + 3];
		int G = matrix[i + 2, j + 4];
		BigInteger sum = A + B + C + D + F + E + G;
		return sum;
	}

	static bool CheckIfPattern(int i, int j)
	{
		int A = matrix[i, j];
		int B = matrix[i, j + 1];
		int C = matrix[i, j + 2];
		int D = matrix[i + 1, j + 2];
		int F = matrix[i + 2, j + 2];
		int E = matrix[i + 2, j + 3];
		int G = matrix[i + 2, j + 4];
		if (A == B - 1 && B == C - 1 && C == D - 1 && D == F - 1 && F == E - 1 && E == G - 1)
		{
			return true;
		}
		return false;
	}

	static void ReadInput()
	{
		n = int.Parse(Console.ReadLine());
		matrix = new int[n, n];
		for (int i = 0; i < n; i++)
		{
			string[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			for (int j = 0; j < n; j++)
			{
				matrix[i, j] = int.Parse(numbers[j].ToString());
			}
		}
	}
}

