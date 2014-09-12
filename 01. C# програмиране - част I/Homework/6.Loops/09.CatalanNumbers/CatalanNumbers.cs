/*
 * In the combinatorial mathematics, the Catalan numbers are calculated by the following formula:
 * (2*n)! / (n + 1)! * n!
 * Write a program to calculate the Nth Catalan number by given N.
 */
using System;
using System.Numerics;
class CatalanNumbers
{
	static void Main()
	{
		Console.Write("N= ");
		int n = int.Parse(Console.ReadLine());

		BigInteger nominator = 1;
		BigInteger denominator = 1;

		for (int i = 1; i <=2*n; i++)
		{
			nominator *= i;
		}
		for (int i = 1; i <= n; i++)
		{
			denominator = denominator * i * (i + 1);;
			
		}

		Console.WriteLine("The {0}th Catalan number is: {1}",n,nominator/denominator);
	}
}

