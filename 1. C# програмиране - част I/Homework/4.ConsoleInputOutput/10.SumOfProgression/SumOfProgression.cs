/*
 * Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...
*/
namespace _10.SumOfProgression
{
	using System;
	class SumOfProgression
	{
		static void Main()
		{
			double sum = 1.0;
			double i = 2;
			while (true)
			{
				if((1/i > 0.001))
				{
					sum = sum + (1/(Math.Pow(-1,i)*i));
					i++;
				}
				else
				{
					break;
				}
			}
			Console.WriteLine("Sum is {0}",sum);
		}
	}
}
