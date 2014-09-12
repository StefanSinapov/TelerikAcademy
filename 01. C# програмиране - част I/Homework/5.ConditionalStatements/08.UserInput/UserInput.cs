/*
 * Write a program that, depending on the user's choice inputs int, double or string variable. 
 * If the variable is integer or double, increases it with 1. 
 * If the variable is string, appends "*" at its end. 
 * The program must show the value of that variable as a console output. 
 * Use switch statement.
 */
using System;
class UserInput
{
	static void Main()
	{
		Console.WriteLine("Please enter <1> for Integer <2> for Double or <3> for String (without <>)");
		Console.Write("Choice = ");
		byte choice = byte.Parse(Console.ReadLine());

		switch (choice)
		{
			case 1:
				Console.Write("Integer number= ");
				int intNumber = int.Parse(Console.ReadLine());
				Console.WriteLine(intNumber + 1);
				break;
			case 2:
				Console.Write("Floating point number= ");
				double floatingNumber = double.Parse(Console.ReadLine());
				Console.WriteLine(floatingNumber + 1);
				break;
			case 3:
				Console.Write("String: ");
				string str = Console.ReadLine();
				Console.WriteLine(str + "*");
				break;
			default: Console.WriteLine("Please enter ,1 for Integer ,2 for Double or 3 for String");
				break;
		}
	}
}

