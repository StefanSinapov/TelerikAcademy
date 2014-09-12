/*
 * Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum. 
*/
namespace _07.SumOfNumbers
{
	using System;
	class SumOfNumbers
	{
		static void Main()
		{
			
			Console.Write("Numbers= ");
			int n = int .Parse(Console.ReadLine());
			double sum=0;
			for (int i = 1; i <= n; i++)
			{
				Console.Write("N{0} = ", i);
				double number = double.Parse(Console.ReadLine());
				sum += number;
			}
			Console.WriteLine("The sum is = {0}",sum);
		}
	}
}
