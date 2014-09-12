/*
 * Write a program to convert binary numbers to hexadecimal numbers (directly).
 */
using System;
using System.Collections.Generic;
using System.Text;
class BinaryToHex
{
	private static readonly Dictionary<string, char> hexCharacterToBinary = new Dictionary<string, char> 
	{
		{  "0000",'0' },
		{  "0001",'1' },
		{  "0010",'2' },
		{  "0011",'3' },
		{  "0100",'4' },
		{  "0101",'5' },
		{  "0110",'6' },
		{  "0111",'7' },
		{  "1000",'8' },
		{  "1001",'9' },
		{  "1010",'A' },
		{  "1011",'B' },
		{  "1100",'C' },
		{  "1101",'D' },
		{  "1110",'E' },
		{  "1111",'F' }
	};
	static string BinToHex(string bin)
	{
		//add 0s in begining
		if (bin.Length % 4 != 0)
		{
			while (bin.Length % 4 != 0)
			{
				bin = "0" + bin;
			}
		}

		//cut on pieces
		int lenght = bin.Length;
		StringBuilder hexNumber = new StringBuilder();
		for (int i = 0; i < lenght; i = i + 4)
		{
			//take 4digits
			StringBuilder temp = new StringBuilder();
			temp.Append(bin, i, 4);

			//add hex 
			hexNumber.Append(hexCharacterToBinary[temp.ToString()]);
		}
		return hexNumber.ToString();

	}
	static void Main()
	{
		Console.Write("Binary number: ");
		string binNumber = Console.ReadLine();
		string hexNumber = BinToHex(binNumber);
		Console.WriteLine("Hexadecimal number: {0}",hexNumber);
	}
}

