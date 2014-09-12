/*
 * Write a program that prints all the numbers from 1 to N.
*/
namespace _01.PrintNumbersOneToN
{
	using System;
	class PrintNumbersOneToN
	{
		static void Main()
		{
			Console.Write("n= ");
			int n = int.Parse(Console.ReadLine());
			int i=1;
			while (i<=n)
			{
				Console.WriteLine(i);
				i++;
			}
		}
	}
}
