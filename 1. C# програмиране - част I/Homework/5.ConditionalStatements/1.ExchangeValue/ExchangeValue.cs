/*
 * Write an if statement that examines two integer variables 
 * and exchanges their values if the first one is greater than the second one.
 */
using System;
class ExchangeValue
{
	static void Main()
	{
		//take the numbers
		int firstNumber = int.Parse(Console.ReadLine());
		int secondNumber = int.Parse(Console.ReadLine());
		
		if(firstNumber>secondNumber)
		{
			//use help variable for exchanging the numbers
			int tempNumber = firstNumber;
			firstNumber = secondNumber;
			secondNumber = tempNumber;
			Console.WriteLine("Numbers was exchanged:  {0}    {1}", firstNumber, secondNumber);
		}

		
	}
}

