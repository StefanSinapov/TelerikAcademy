/*
 * Write a program to print the first 100 members of the 
 * sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
*/
using System;
using System.Numerics;
class Program
{
	static void Main()
	{
		BigInteger[] fibonacci = new BigInteger[103];
		fibonacci[0] = 0;
		fibonacci[1] = 1;
		for (int i = 1; i < 102; i++)
		{
			Console.WriteLine(fibonacci[i-1]);
			fibonacci[i + 1] = fibonacci[i] + fibonacci[i - 1];
		}
		
		
	}
}

