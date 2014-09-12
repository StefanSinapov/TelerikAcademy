/*
 * Write a program that reads the coefficients a, b and c of a quadratic equation 
 * ax2+bx+c=0 and solves it (prints its real roots).
 */

namespace _06.QuadraticEquation
{
	using System;
	class QuadraticEquation
	{
		static void Main(string[] args)
		{
			Console.WriteLine("a*x^2 + b*x + c = 0");
			Console.Write("a= ");
			double a = int.Parse(Console.ReadLine());
			Console.Write("b= ");
			double b = int.Parse(Console.ReadLine());
			Console.Write("c= ");
			double c = int.Parse(Console.ReadLine());

			double determinante = Math.Pow(b, 2) - 4 * a * c;

			if(a==0)
			{
				Console.WriteLine("X={0}",-c/b);
			}
			else if(determinante>0)
			{
				double x1 = ((-b + Math.Sqrt(determinante)) / 2 * a);
				double x2 = ((-b - Math.Sqrt(determinante)) / 2 * a);
				Console.WriteLine("X1={0}  X2={1}",x1,x2);
			}
			else if(determinante==0)
			{
				double x1 = (-b) / 2 * a;
				Console.WriteLine("D=0 X1=X2={0}",x1);
			}
			else 
			{
				Console.WriteLine("No real roots");
			}
		}
	}
}
