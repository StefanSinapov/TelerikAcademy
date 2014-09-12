/*
 * Write methods that calculate the surface of a triangle by given:
	 * Side and an altitude to it;
	 * Three sides;
	 * Two sides and an angle between them.
 */
using System;
class SurfaceOfTriangle
{
	static void TriangleSurfaceSideAndAltitude()
	{
		Console.Write("Side: ");
		double a = double.Parse(Console.ReadLine());

		Console.Write("Altitude: ");
		double h = double.Parse(Console.ReadLine());

		if (a <= 0 || h <= 0)
			throw new ArgumentOutOfRangeException();

		Console.WriteLine("Area is: {0} ", (a * h) / 2);
	}
	static void TriangleSurfaceThreeSides()
	{
		Console.Write("Side A: ");
		double a = double.Parse(Console.ReadLine());

		Console.Write("Side B: ");
		double b = double.Parse(Console.ReadLine());

		Console.Write("Side C: ");
		double c = double.Parse(Console.ReadLine());

		if (a <= 0 || b <= 0 || c <= 0 || a + b < c || a + b < b || b + c < a)
			throw new ArgumentOutOfRangeException();

		double p = (a + b + c) / 2;
		double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

		Console.WriteLine("Area is: {0} \n", area);
	}
	static void TriangleSurfaceTwoSidesAndAngle()
	{
		Console.Write("Side A: ");
		double a = double.Parse(Console.ReadLine());

		Console.Write("Side B: ");
		double b = double.Parse(Console.ReadLine());

		Console.Write("Enter angle's degrees: ");
		double angle = double.Parse(Console.ReadLine());

		if (a <= 0 || b <= 0 || angle <= 0 || angle >= 180)
			throw new ArgumentOutOfRangeException();

		Console.WriteLine("Area is: {0}", (a * b * Math.Sin(angle)) / 2);
	}
	static void Main()
	{
		Console.WriteLine("Choose triangle's details to calculate its surface: ");
		Console.WriteLine("1) Side and an altitude to it");
		Console.WriteLine("2) Three sides");
		Console.WriteLine("3) Two sides and an angle between them");
		Console.Write("\nEnter your choice: ");
		int userChoice = int.Parse(Console.ReadLine());

		switch (userChoice)
		{
			case 1: TriangleSurfaceSideAndAltitude(); break;
			case 2: TriangleSurfaceThreeSides(); break;
			case 3: TriangleSurfaceTwoSidesAndAngle(); break;
			default: Console.WriteLine("Error! Invalid input data!"); break;
		}
	}
}

