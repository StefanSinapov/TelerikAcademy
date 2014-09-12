/*
 * Write a program that prints to the console which day of the week is today. Use System.DateTime.
 */
using System;
class DayOfTheWeek
{
	static void Main()
	{
		DateTime today = DateTime.Now;
		Console.WriteLine("Day of week today is: {0}", today.DayOfWeek); 
	}
}

