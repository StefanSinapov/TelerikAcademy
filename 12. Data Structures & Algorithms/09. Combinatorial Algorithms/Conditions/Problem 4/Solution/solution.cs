using System;
using System.Collections.Generic;

class SequenceOfColorfulBalls
{
	static void Main()
	{
		string ballsStr = Console.ReadLine();
		char[] balls = ballsStr.ToCharArray();
		
		//long sequencesCountSlow = CountSequencesSlow(balls);
		//Console.WriteLine("Slow: " + sequencesCountSlow);

		//long sequencesCountOverflow = CountSequencesOverflow(balls);
		//Console.WriteLine("Overflow: " + sequencesCountOverflow);

		long sequencesCount = CountSequencesFast(balls);
		Console.WriteLine(sequencesCount);
	}

	private static long CountSequencesSlow(char[] balls)
	{
		HashSet<string> sequences = new HashSet<string>();
		GenerateAllPermutations(balls, 0, sequences);
		foreach (var s in sequences)
		{
			Console.WriteLine(s);
		}
		return sequences.Count;
	}

	private static void GenerateAllPermutations(
		char[] balls, int start, HashSet<string> sequences)
	{
		if (start == balls.Length-1)
		{
			sequences.Add(new String(balls));
			return;
		}
		GenerateAllPermutations(balls, start + 1, sequences);
		for (int i = start; i < balls.Length; i++)
		{
			Swap(ref balls[start], ref balls[i]);
			GenerateAllPermutations(balls, start + 1, sequences);
			Swap(ref balls[start], ref balls[i]);
		}
	}

	private static void Swap<T>(ref T first, ref T second)
	{
		T old = first;
		first = second;
		second = old;
	}

	private static long CountSequencesOverflow(char[] balls)
	{
		// We calculate directly the formula n! / (c1! * c2! * ... ck!)
		// where c1, c2, .. ck are the number of the balls fo each color

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
		long result = 1;
		for (int i = 2; i <= n; i++)
		{
			result *= i;
		}
		return result;
	}

	private static long CountSequencesFast(char[] balls)
	{
		// We calculate smartly the formula n! / (c1! * c2! * ... ck!)
		// where c1, c2, .. ck are the number of the balls fo each color

		int n = balls.Length;

		// Collect the divisors of all numerators
		int[] numerators = new int[n + 1];
		for (int i = 2; i <= n; i++)
		{
			AddDivisors(i, numerators);
		}

		// Collect the divisors of all denominators
		int[] ballCounts = new int['Z' + 1];
		foreach (var ball in balls)
		{
			ballCounts[ball]++;
		}
		int[] denominators = new int[n + 1];
		for (int i = 'A'; i <= 'Z'; i++)
		{
			int ballsOfCertainColor = ballCounts[i];
			for (int count = 2; count <= ballsOfCertainColor; count++)
			{
				AddDivisors(count, denominators);
			}
		}

		// Use C# keyword "checked" to ensure integer overflow is not possible
		checked
		{
			// Smartly multiply all numerators and divide by all denominators
			long result = 1;
			for (int div = 2; div <= n; div++)
			{
				int count = numerators[div] - denominators[div];
				for (int i = 0; i < count; i++)
				{
					result *= div;
				}
			}
			return result;
		}
	}

	private static void AddDivisors(int n, int[] divisors)
	{
		// Extract all prime divisors of given number N and
		// increase the count of each divisors in the given array

		int div = 2;
		while (n > 1)
		{
			if (n % div == 0)
			{
				divisors[div]++;
				n = n / div;
			}
			else
			{
				div++;
			}
		}
	}
}
