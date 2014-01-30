/*
 * Write a program that gets two numbers from the console and prints the greater of them. 
 * Don’t use if statements.
*/
namespace _05.GreterNumber
{
	using System;
	class GreaterNumber
	{
		static void Main()
		{
			double firstNumber = double.Parse(Console.ReadLine());
			double secondNumber = double.Parse(Console.ReadLine());

			Console.WriteLine("The greater number of {0} and {1} is: {2}",firstNumber,secondNumber,Math.Max(firstNumber,secondNumber));
		}
	}
}
