using System;
using System.Text;
class AreaOfTrapezoid
{
	static void Main()
	{
		//Write an expression that calculates trapezoid's area by given sides a and b and height h.
		Console.OutputEncoding = Encoding.Unicode;
		Console.Write("a= ");
		double a = double.Parse(Console.ReadLine());
		Console.Write("b= ");
		double b = double.Parse(Console.ReadLine());
		Console.Write("h= ");
		double h = double.Parse(Console.ReadLine());
		Console.WriteLine("The area is :{0}",((a+b)*h)/2);

	}
}

