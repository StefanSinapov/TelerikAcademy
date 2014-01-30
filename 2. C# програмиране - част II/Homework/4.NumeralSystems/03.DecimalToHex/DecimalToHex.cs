/*
 * Write a program to convert decimal numbers to their hexadecimal representation.
 */
using System;
class DecimalToHex
{
	static string Reverse(string text)
	{
		if (text == null) return null;

		char[] array = text.ToCharArray();
		Array.Reverse(array);
		return new String(array);
	}
	static void Main()
	{
		Console.Write("Please enter decimal number: ");
		int decNumber = int.Parse(Console.ReadLine());
		string hexNumber = "";
		do
		{
			if((decNumber%16)<10)
			{
				hexNumber += decNumber % 16;
			}
			else
			{
				switch (decNumber%16)
				{
					case 10:
						hexNumber += "A";
						break;
					case 11:
						hexNumber += "B";
						break;
					case 12:
						hexNumber += "C";
						break;
					case 13:
						hexNumber += "D";
						break;
					case 14:
						hexNumber += "E";
						break;
					case 15:
						hexNumber += "F";
						break;
					default:
						break;
				}
			}
			decNumber /= 16;
		} while (decNumber!=0);

		//now just reverse the string
		hexNumber = Reverse(hexNumber);

		Console.WriteLine(hexNumber);

	}
}

