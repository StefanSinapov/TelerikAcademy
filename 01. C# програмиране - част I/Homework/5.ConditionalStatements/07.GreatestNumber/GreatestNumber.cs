//Write a program that finds the greatest of given 5 variables.
using System;
class GreatestNumber
{
	static void Main()
	{
		Console.WriteLine("Please enter five numbers");
		Console.Write("first number= ");
		double firstNumber=double.Parse(Console.ReadLine());
		double greatestNumber=firstNumber;
		Console.Write("second number= ");
		double secondNumber = double.Parse(Console.ReadLine());
		Console.Write("third number= ");
		double thirdNumber = double.Parse(Console.ReadLine());
		Console.Write("fourth number= ");
		double fourthNumber = double.Parse(Console.ReadLine());
		Console.Write("fifth number= ");
		double fifthNumber = double.Parse(Console.ReadLine());

		if(secondNumber>greatestNumber)
		{
			greatestNumber = secondNumber;
		}
		if (thirdNumber > greatestNumber)
		{
			greatestNumber = thirdNumber;
		}
		if (fourthNumber > greatestNumber)
		{
			greatestNumber = fourthNumber;
		}
		if (fifthNumber > greatestNumber)
		{
			greatestNumber = fifthNumber;
		}

		Console.WriteLine("The greatest number is {0}",greatestNumber);

	}
}

