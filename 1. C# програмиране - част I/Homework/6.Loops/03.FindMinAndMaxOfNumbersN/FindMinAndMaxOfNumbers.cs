/*
 * Write a program that reads from the console a sequence of N integer numbers 
 * and returns the minimal and maximal of them.
*/
namespace _03.FindMinAndMaxOfNumbersN
{
	using System;
	class FindMinAndMaxOfNumbers
	{
		static void Main()
		{
			Console.Write("n= ");
			int n = int.Parse(Console.ReadLine());
			int[] numbers = new int[n];
			for (int i = 0; i < n; i++)
			{
				Console.Write("Number №{0} = ",i+1);
				numbers[i] = int.Parse(Console.ReadLine());
			}
			Array.Sort(numbers);
			Console.WriteLine("Minimal number= {0} and Maximal number= {1}",numbers[0],numbers[n-1]);
		}
	}
}
