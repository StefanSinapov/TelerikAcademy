/*
 * Write a program to convert hexadecimal numbers to their decimal representation.
 */
using System;
class HexToDecimal
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
		Console.Write("Hexadecimal number: ");
		string hexNumber = Console.ReadLine();
		hexNumber=hexNumber.ToUpper();
		int decNumber = 0;
		int lenght = hexNumber.Length;
		for (int i = 0; i < lenght; i++)
		{
			switch (hexNumber[i])
			{
				case 'A':
					decNumber += 10 * (int)Pow(16, lenght - i - 1);
					continue;
				case 'B':
					decNumber += 11 * (int)Pow(16, lenght - i - 1);
					continue;
				case 'C':
					decNumber += 12 * (int)Pow(16, lenght - i - 1);
					continue;
				case 'D':
					decNumber += 13 * (int)Pow(16, lenght - i - 1);
					continue;
				case 'E':
					decNumber += 14 * (int)Pow(16, lenght - i - 1);
					continue;
				case 'F':
					decNumber += 15 * (int)Pow(16, lenght - i - 1);
					continue;
				default:
					break;
			}
			decNumber += int.Parse(hexNumber[i].ToString()) * (int)Pow(16, lenght - i - 1);
		}

		Console.WriteLine("Decimal: {0}", decNumber);
	}
}

