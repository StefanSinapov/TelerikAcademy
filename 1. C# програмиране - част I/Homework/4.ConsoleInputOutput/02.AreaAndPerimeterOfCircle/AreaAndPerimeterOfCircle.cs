namespace _02.AreaAndPerimeterOfCircle
{
	using System;

	class AreaAndPerimeterOfCircle
	{
		static void Main()
		{
			Console.Write("r= ");
			double r = double.Parse(Console.ReadLine());

			Console.WriteLine("The parimeter is {3:0.00}, or {4}П \nThe area of circle (0,{0}) is {1:0.00} or {2}П",r,Math.PI*Math.Pow(r,2),Math.Pow(r,2),Math.PI*2*r,2*r);

		}
	}
}
//Write a program that reads the radius r of a circle and prints its perimeter and area.
