/*
 * Write a program that reads from the console a positive integer number N (N < 20) 
 * and outputs a matrix like the following:
	N = 3			N = 4
	1 2 3		   1 2 3 4
	2 3 4		   2 3 4 5
    3 4 5		   3 4 5 6
 				   4 5 6 7
 */
using System;
class Matrix
{
	static void Main()
	{
		Console.Write("N= ");
		int n = int.Parse(Console.ReadLine());
		if (n > 0 && n < 20)
		{
			for (int i = 1; i <= n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					Console.Write("{0} ", i + j);
				}
				Console.WriteLine();
			}
		}
		else
		{
			Console.WriteLine("0<n<20");
		}

	}
}

