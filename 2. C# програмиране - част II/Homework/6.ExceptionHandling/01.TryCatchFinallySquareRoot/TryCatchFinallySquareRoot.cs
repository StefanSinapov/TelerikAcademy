/*
 * Write a program that reads an integer number and calculates and prints its square root.
 * If the number is invalid or negative, print "Invalid number". 
 * In all cases finally print "Good bye". Use try-catch-finally.
 */
using System;
class TryCatchFinallySquareRoot
{
	static double Sqrt(double value)
	{
		if (value < 0)
			throw new NotImplementedException(
			   "Sqrt for negative numbers is undefined!");
		return Math.Sqrt(value);
	}
	static void Main()
	{

		Console.Write("Please enter integer number: ");
		try
		{
			int number = int.Parse(Console.ReadLine());
			Console.WriteLine("Square root of {0} is {1}", number, Sqrt(number));

		}
		catch (FormatException fe)
		{
			Console.WriteLine("Invalid number -> {0}", fe.Message);
		}
		catch (OverflowException oe)
		{
			Console.Error.WriteLine("Invalid number -> {0}", oe.Message);
		}
		catch (NotImplementedException ex)
		{
			Console.Error.WriteLine("Invalid number -> {0}", ex.Message);
		}
		finally
		{
			Console.WriteLine("Good bye");
		}
	}
}

