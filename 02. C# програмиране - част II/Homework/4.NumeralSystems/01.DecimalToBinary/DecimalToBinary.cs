/*
 * Write a program to convert decimal numbers to their binary representation.
 */
using System;
class DecimalToBinary
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
		Console.Write("Please enter decimal number to be converted to binary: ");
		int decNumber = int.Parse(Console.ReadLine());
		string binNumber="";
		do
		{
			binNumber += (decNumber % 2).ToString();
			decNumber /= 2;
		} while (decNumber!=0);

		//now to reverse the string using method
		binNumber = Reverse(binNumber);

		Console.WriteLine("The binary representation is: {0}",binNumber);
	}
}

