using System;
using System.Text;
class PointInCicle
{
	static void Main()
	{
		//Write an expression that checks if given point (x,  y) is within a circle K(O, 5).

		Console.OutputEncoding = Encoding.Unicode;
		Console.Write("x= ");
		int x = int.Parse(Console.ReadLine());
		Console.Write("y= ");
		int y = int.Parse(Console.ReadLine());
		int radius=5;

		//I use Pythagoras to measure the distance between your point and the centre and see if it's lower than the radius
		if((x*x) +(y*y)<(radius*radius))
		{
			Console.WriteLine("точката е в окръжността");
		}
		else 
		{
			Console.WriteLine("не е в окръжността");
		}
	}
}

