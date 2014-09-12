/*
 * Write a program to convert hexadecimal numbers to binary numbers (directly).
 */
using System;
using System.Collections.Generic;
using System.Text;
class HexToBinary
{
	private static readonly Dictionary<char, string> hexCharacterToBinary = new Dictionary<char, string> 
	{
		{ '0', "0000" },
		{ '1', "0001" },
		{ '2', "0010" },
		{ '3', "0011" },
		{ '4', "0100" },
		{ '5', "0101" },
		{ '6', "0110" },
		{ '7', "0111" },
		{ '8', "1000" },
		{ '9', "1001" },
		{ 'A', "1010" },
		{ 'B', "1011" },
		{ 'C', "1100" },
		{ 'D', "1101" },
		{ 'E', "1110" },
		{ 'F', "1111" }
	};
	static string HexToBin(string hexNumber)
	{
		hexNumber.ToUpper();
		StringBuilder binNumber = new StringBuilder();
		foreach (char c in hexNumber)
		{
			binNumber.Append(hexCharacterToBinary[char.ToUpper(c)]);
		}
		return binNumber.ToString();
	}
	static void Main()
	{
		Console.WriteLine("Hexadecimal number: ");
		string hexNumber = Console.ReadLine();

		string binNumber = HexToBin(hexNumber);

		Console.WriteLine("Binary number: {0}",binNumber);
	}
}

