/*
 * Write a program that reads a string, reverses it and prints the result at the console.
Example: "sample"  "elpmas".
 */
using System;
using System.Text;
class ReverseString
{
	static void Main()
	{
		Console.WriteLine("Please enter text to be reversed...");
		string text = Console.ReadLine();
		StringBuilder reversedText = new StringBuilder();

		for (int i = text.Length-1; i >= 0; i--)
		{
			reversedText.Append(text[i]);
		}

		Console.WriteLine("Reversed text is: {0}",reversedText.ToString());
	}
}

