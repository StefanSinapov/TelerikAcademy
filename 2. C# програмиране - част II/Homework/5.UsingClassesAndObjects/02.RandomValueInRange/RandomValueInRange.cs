/*
 * Write a program that generates and prints to the console 10 random values in the range [100, 200].
 */
using System;
class RandomValueInRange
{
	static void Main()
	{
		Console.WriteLine("10 Random values in the range [100, 200]");
		Random randomNumber = new Random();
		for (int i = 0; i < 10; i++)
		{
			int number = randomNumber.Next(100, 200);
			Console.WriteLine(number);
		}
	}
}

