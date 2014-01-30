namespace _01.ReadAndPrintSumOfNumbers
{
	using System;
	class ReadAndPrintSumOfNumbers
	{
		static void Main()
		{
			Console.Write("First number: ");
			int firstNumber = int.Parse(Console.ReadLine());

			Console.Write("Second number: ");
			int secondNumber = int.Parse(Console.ReadLine());

			Console.Write("Third number: ");
			int thirdNumber = int.Parse(Console.ReadLine());

			Console.WriteLine("The sum of {0}+{1}+{2} = {3}",firstNumber,secondNumber,thirdNumber,firstNumber+secondNumber+thirdNumber);
		}
	}
}
//Write a program that reads 3 integer numbers from the console and prints their sum.
