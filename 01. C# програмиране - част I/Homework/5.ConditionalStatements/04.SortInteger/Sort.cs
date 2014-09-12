//Sort 3 real values in descending order using nested if statements.
using System;
class Sort
{
	static void Main()
	{
		Console.Write("First Number = ");
		double firstNumber = double.Parse(Console.ReadLine());
		Console.Write("Second Number = ");
		double secondNumber = double.Parse(Console.ReadLine());
		Console.Write("Third Number = ");
		double thirdNumber = double.Parse(Console.ReadLine());
		double buffer;
		if(firstNumber>secondNumber)
		{
			buffer = firstNumber;
			firstNumber = secondNumber;
			secondNumber = buffer;
		}
		if(firstNumber>thirdNumber)
		{
			buffer = firstNumber;
			firstNumber = thirdNumber;
			thirdNumber = buffer;
		}
		if(secondNumber>thirdNumber)
		{
			buffer = secondNumber;
			secondNumber = thirdNumber;
			thirdNumber = buffer;
		}
		Console.WriteLine("Sorted {0}, {1}, {2}",firstNumber,secondNumber,thirdNumber);
	}
}

