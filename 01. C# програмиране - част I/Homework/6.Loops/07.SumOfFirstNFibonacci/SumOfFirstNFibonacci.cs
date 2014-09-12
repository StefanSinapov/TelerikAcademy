/*
 * Write a program that reads a number N and calculates the sum of the first
 * N members of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
*/
namespace _07.SumOfFirstNFibonacci
{
	using System;
	class SumOfFirstNFibonacci
	{
		static void Main()
		{
			Console.WriteLine("Please enter numbers N>0 and I'll give you the sum of first N Fibonacci numbers");
			Console.Write("N = ");
			int n = int.Parse(Console.ReadLine());

			decimal sum = 0;
			decimal[] fibonacci = new decimal[n+2];
			fibonacci[0] = 0;
			fibonacci[1] = 1;
			for (int i = 0; i < n; i++)
			{
				fibonacci[i+2] = fibonacci[i] + fibonacci[i+1];
				sum = sum + fibonacci[i];
			}
			Console.WriteLine(sum);
		}
	}
}
