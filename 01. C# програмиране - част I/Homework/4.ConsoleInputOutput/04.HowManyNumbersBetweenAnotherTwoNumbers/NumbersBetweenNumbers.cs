/*Write a program that reads two positive integer 
 * numbers and prints how many numbers p exist between them such 
 * that the reminder of the division by 5 is 0 (inclusive). 
 * Example: p(17,25) = 2.
 */

namespace _04.HowManyNumbersBetweenAnotherTwoNumbers
{
	using System;
	class NumbersBetweenNumbers
	{
		static void Main()
		{
			int firstNumber = int.Parse(Console.ReadLine());
			int secondNumber = int.Parse(Console.ReadLine());
			int counter = 0;
			if(firstNumber>0 && secondNumber>0)
			{
				for (int i = firstNumber; i <= secondNumber; i++)
				{
					if(i%5==0)
					{
						counter++;
					}
				}
				Console.WriteLine("p({0},{1})={2}",firstNumber,secondNumber,counter);
			}
			else 
			{
				Console.WriteLine("Please try again with positive numbers");
			}
		}
	}
}
