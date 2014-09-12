/*
 * Define a class InvalidRangeException<T> that holds information about an error condition related to invalid range.
 * It should hold error message and a range definition [start … end].

 * Write a sample application that demonstrates the InvalidRangeException<int> 
 * and InvalidRangeException<DateTime> by entering numbers in the range [1..100] and 
 * dates in the range [1.1.1980 … 31.12.2013].
 */
using System;
class Program
{
	static void Main()
	{
		InvalidRangeException<int> integerException = new InvalidRangeException<int>("Value must be in range 1 - 100", 1, 100);
		InvalidRangeException<DateTime> dateException = new InvalidRangeException<DateTime>("Date must be between 1.1.1980 and 31.12.2013",
			new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));

		Console.WriteLine("Please enter 3 number in range [1-100]");
		for (int i = 0; i < 3; i++)
		{
			int number = int.Parse(Console.ReadLine());
			if (number < integerException.Min || number > integerException.Max)
				throw integerException;
		}


		Console.WriteLine("Please inter 3 dates in range [1.1.1980 … 31.12.2013]");
		for (int i = 0; i < 3; i++)
		{
			DateTime date = DateTime.Parse(Console.ReadLine());
			if (date < dateException.Min || date > dateException.Max)
				throw dateException;
		}
	}
}
