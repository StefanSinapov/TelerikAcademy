/*
 * Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).
		Example: The target substring is "in". The text is as follows:
 * 
 * We are living in an yellow submarine. We don't have anything else. 
 * Inside the submarine is very tight. So we are drinking all the day. 
 * We will move out of it in 5 days.

	The result is: 9.
*/
using System;
using System.Text.RegularExpressions;
class SubString
{
	static void Main()
	{
		Console.WriteLine("Please enter your text.");
		string text = Console.ReadLine();

		Console.Write("Please enter searched text: ");
		string subString = Console.ReadLine();


	
		//int index = text.IndexOf("in", StringComparison.OrdinalIgnoreCase);
		//int counter = 0;

		//while (index != -1)
		//{
		//	counter++;
		//	index = text.IndexOf("in", index + 1, StringComparison.OrdinalIgnoreCase);
		//}


		//second way (need System.Text.RegularExpressions library)
		int counter = Regex.Matches(text, subString, RegexOptions.IgnoreCase).Count;
		if (counter > 0)
		{
			Console.WriteLine("The result is: {0}", counter);
		}
		else
		{
			Console.WriteLine("The word {0} is not found", subString);
		}
	}
}

