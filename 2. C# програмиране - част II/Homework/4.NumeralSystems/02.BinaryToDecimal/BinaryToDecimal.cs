/*
 * Write a program to convert binary numbers to their decimal representation.
 */
using System;
class BinaryToDecimal
{
	static double Pow(int number, int power)
	{
		if (power == 0)
		{
			return 1;
		}
		double pass = number;
		for (int ct = 1; ct < power; ct++)
		{
			pass *= number;
		}

		return pass;
	}
	static void Main()
	{
		Console.Write("Please enter binary number: ");
		string binNumber = Console.ReadLine();
		int decNumber = 0;
		int lenght = binNumber.Length;

		for (int i = 0; i < lenght; i++)
		{
			decNumber += int.Parse(binNumber[i].ToString()) * (int)Pow(2, lenght - i - 1);
		}

		Console.WriteLine("In decimal {0}", decNumber);
	}
}

