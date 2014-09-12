/*
 * Write a program that shows the sign (+ or -) 
 * of the product of three real numbers without calculating it. 
 * Use a sequence of if statements.
 */
using System;
class ShowTheSignOfProduct
{
	static void Main()
	{
		Console.Write("First Number = ");
		double firstNumber = double.Parse(Console.ReadLine());
		Console.Write("Second Number = ");
		double secondNumber = double.Parse(Console.ReadLine());
		Console.Write("Third Number = ");
		double thirdNumber = double.Parse(Console.ReadLine());
		/*if((firstNumber*secondNumber*thirdNumber)>0)
		{
			Console.WriteLine("sign of the product is (+)");
		}
		else
		{
			Console.WriteLine("sign of the product is (-)");
		}*/

		int signCounter = 0;

		if ((firstNumber == 0) || (secondNumber == 0) || (thirdNumber == 0))
		{
			Console.WriteLine("The product is 0");
		}

		else
		{
			if (firstNumber < 0)
			{
				signCounter++;
			}
			if (secondNumber < 0)
			{
				signCounter++;
			}
			if (thirdNumber < 0)
			{
				signCounter++;
			}

			if (signCounter % 2 == 0)
			{
				Console.WriteLine("The sign of the product is (+) ");
			}
			else
			{
				Console.WriteLine("The sign of the product is (-) ");
			}

		}
	}
}

