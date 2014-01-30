/*
 * Write a program that reads from the console a string of maximum 20 characters.
 * If the length of the string is less than 20, the rest of the characters should be filled with '*'. 
 * Print the result string into the console.
 */
using System;
using System.Text;
class StringFilledWithStars
{
	static void Main()
	{
		Console.Write("Please enter text (max 20 symbols): ");
		string text = Console.ReadLine();

		text = text.PadRight(20, '*');

		Console.WriteLine(text);
	}
}

