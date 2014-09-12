/*
 * Write a program that calculates the greatest common divisor 
 * (GCD) of given two numbers. 
 * Use the Euclidean algorithm (find it in Internet).
 */
using System;
class GreatestCommonDivisor
{
	static void Main()
	{
		Console.Write("First number= ");
		int firstNumber = int.Parse(Console.ReadLine());
		Console.Write("Second number= ");
		int secondNumber = int.Parse(Console.ReadLine());

		if(firstNumber>secondNumber)
		{
			firstNumber = firstNumber + secondNumber;
			secondNumber = firstNumber - secondNumber;
			firstNumber = firstNumber - secondNumber;
		}

		int GCD=0;

		while (secondNumber != 0)
		{
			GCD = firstNumber % secondNumber;
			firstNumber = secondNumber;
			if (GCD == 0)
			{
				GCD = secondNumber;
				secondNumber = 0;  // cleanly exit the loop
				//break;  // I do not like doing this.
			}
			else
			{
				secondNumber = GCD; // do this only if we need to loop again
			}
		}
		Console.WriteLine("The Greatest common divisor is: {0}",GCD);
	}
}

