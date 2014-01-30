/*
 * Write a program to check if in a given expression the brackets are put correctly.
 * Example of correct expression: ((a+b)/5-d).
 * Example of incorrect expression: )(a+b)).
 */
using System;
class CheckBrackets
{
	static void Main()
	{
		Console.Write("Plese enter expression: ");
		string expression = Console.ReadLine();

		int bracketsCounter = 0;
		bool incorect = false;

		foreach (char symbol in expression)
		{
			if (symbol=='(')
			{
				bracketsCounter++;
			}
			else if(symbol==')')
			{
				bracketsCounter--;
			}
		}

		if(bracketsCounter==0)
		{
			Console.WriteLine("Expression {0} is correct!",expression);
		}
		else
		{
			Console.WriteLine("Expression {0} is incorrect!",expression);
		}
	}
}

