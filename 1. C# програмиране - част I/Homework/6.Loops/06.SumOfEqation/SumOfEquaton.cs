/*
 * Write a program that, for a given two integer numbers N and X, 
 * calculates the sumS = 1 + 1!/X + 2!/X2 + … + N!/XN
*/
namespace _06.SumOfEqation
{
	using System;
	class SumOfEquaton
	{
		static void Main()
		{
			Console.WriteLine("Please enter numbers N and X (0<=N 0<X) and i'll calculate the sumS = 1 + 1!/X + 2!/X2 + … + N!/X^N ");
			Console.Write("N = ");
			int n = int.Parse(Console.ReadLine());
			Console.Write("X = ");
			int x = int.Parse(Console.ReadLine());

			if(n>=0 && x>0)
			{
				decimal sum = 1m;
				decimal addend;
				long nominator=1;
				decimal denominator = 1;
				for (int i = 1; i <= n; i++)
				{
					nominator *= i;
					denominator *= x;
					addend = nominator / denominator;
					sum = sum + addend;
				}
				Console.WriteLine(sum);
			}
			else
			{
				Console.WriteLine("Please enter valide data N>0 and X>0 ");
			}
		}
	}
}
