/*
 * Write a program that finds the biggest of three integers using nested if statements.
 */
using System;
class FindTheBiggestNumber
{
	static void Main()
	{
		Console.Write("First Number = ");
		int firstNumber = int.Parse(Console.ReadLine());
		Console.Write("Second Number = ");
		int secondNumber = int.Parse(Console.ReadLine());
		Console.Write("Third Number = ");
		int thirdNumber = int.Parse(Console.ReadLine());
		int theBiggestNumber;
		if(firstNumber>secondNumber && firstNumber>thirdNumber)
		{
			theBiggestNumber = firstNumber;
		}
		else if(secondNumber>firstNumber && secondNumber>thirdNumber)
		{
			theBiggestNumber = secondNumber;
		}
		else if(thirdNumber>firstNumber && thirdNumber>secondNumber)
		{
			theBiggestNumber = thirdNumber;
		}
		else if(firstNumber==secondNumber && firstNumber>thirdNumber)
		{
			theBiggestNumber = firstNumber;
		}
		else if(firstNumber==thirdNumber && firstNumber>secondNumber)
		{
			theBiggestNumber = firstNumber;
		}
		else if(secondNumber==thirdNumber && secondNumber >firstNumber)
		{
			theBiggestNumber = secondNumber;
		}
		else
		{
			theBiggestNumber = firstNumber;
		}

		Console.WriteLine("The biggest number is {0}",theBiggestNumber);
	}
}
