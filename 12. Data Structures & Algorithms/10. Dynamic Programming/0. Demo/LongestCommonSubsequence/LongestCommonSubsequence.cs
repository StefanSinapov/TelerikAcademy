using System;
using System.Collections.Generic;

class LongestCommonSubsequence
{
	const int NOT_CALCULATED = -1;

	static string firstStr = "xabcxxxx";
	static string secondStr = "abcxxyxabcx";
	static int[,] lcs = new int[firstStr.Length, secondStr.Length];

	static void Main()
	{
		InitializeLCS();

		CalcLCS(firstStr.Length - 1, secondStr.Length - 1);
		
		PrintLCS(firstStr.Length - 1, secondStr.Length - 1);
	}

	static void InitializeLCS()
	{
		for (int x = 0; x < firstStr.Length; x++)
		{
			for (int y = 0; y < secondStr.Length; y++)
			{
				lcs[x, y] = NOT_CALCULATED;
			}
		}
	}
	
	static int CalcLCS(int x, int y)
	{
		if (x < 0 || y < 0)
		{
			return 0;
		}

		if (lcs[x, y] == NOT_CALCULATED)
		{
			int lcsFirstMinusOne = CalcLCS(x - 1, y);
			int lcsSecondMinusOne = CalcLCS(x, y - 1);
			lcs[x, y] = Math.Max(lcsFirstMinusOne, lcsSecondMinusOne);
			if (firstStr[x] == secondStr[y])
			{
				int lcsBothMinusOne = 1 + CalcLCS(x - 1, y - 1);
				lcs[x, y] = Math.Max(lcs[x, y], lcsBothMinusOne);
			}
		}

		return lcs[x, y];
	}

	static void PrintLCS(int x, int y)
	{
		Console.WriteLine("LCS = " + CalcLCS(x, y));

		List<char> lcsLetters = new List<char>();
		while (x >= 0 && y >= 0)
		{
			if ((firstStr[x] == secondStr[y]) &&
				(CalcLCS(x - 1, y - 1) + 1 == lcs[x, y]))
			{
				lcsLetters.Add(firstStr[x]);
				x--;
				y--;
			}
			else if (CalcLCS(x - 1, y) == lcs[x, y])
			{
				x--;
			}
			else
			{
				y--;
			}
		}
		lcsLetters.Reverse();
		string lcsStr = string.Join("", lcsLetters);
		Console.WriteLine(lcsStr);
	}
}
