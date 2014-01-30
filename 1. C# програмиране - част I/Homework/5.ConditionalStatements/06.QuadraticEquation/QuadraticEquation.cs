/*
 * Write a program that enters the coefficients a, b and c of a quadratic equation
 * a*x2 + b*x + c = 0
 * and calculates and prints its real roots. 
 * Note that quadratic equations may have 0, 1 or 2 real roots.
 */
using System;
class QuadraticEquation
{
	static void Main()
	{
		Console.WriteLine("a*x^2 + b*x + c = 0");
		Console.Write("a= ");
		double a = int.Parse(Console.ReadLine());
		Console.Write("b= ");
		double b = int.Parse(Console.ReadLine());
		Console.Write("c= ");
		double c = int.Parse(Console.ReadLine());

		double determinante = Math.Pow(b, 2) - 4 * a * c;

		if (a == 0)
		{
			Console.WriteLine("X={0}", -c / b);
		}
		else if (determinante > 0)
		{
			double x1 = ((-b + Math.Sqrt(determinante)) / 2 * a);
			double x2 = ((-b - Math.Sqrt(determinante)) / 2 * a);
			Console.WriteLine("X1={0}  X2={1}", x1, x2);
		}
		else if (determinante == 0)
		{
			double x1 = (-b) / 2 * a;
			Console.WriteLine("D=0 X1=X2={0}", x1);
		}
		else
		{
			Console.WriteLine("No real roots");
		}
	}
}

