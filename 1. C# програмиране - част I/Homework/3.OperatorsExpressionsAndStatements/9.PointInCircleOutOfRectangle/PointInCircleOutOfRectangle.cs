using System;
class PointInCircleOutOfRectangle
{
	static void Main()
	{
		//Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3) 
		//and out of the rectangle R(top=1, left=-1, width=6, height=2).
		Console.Write("x= ");
		double Xp = double.Parse(Console.ReadLine());
		Console.Write("y= ");
		double Yp = double.Parse(Console.ReadLine());
		if(((Xp-1)*(Xp-1) +(Yp-1)*(Yp-1))<=3*3)
		{
			Console.Write("the point is IN the circle and ");
			if ((Xp >= -1 && Xp <= 5) && (Yp >= -1 && Yp <= 1))
			{
				Console.WriteLine("INSIDE Rectangle");
			}
			else 
			{
				Console.WriteLine("OUTSIDE Rectangle");
			}
			
		}
		else
		{
			Console.Write("The point is OUTSIDE the circle and ");
			if ((Xp >= -1 && Xp <= 5) && (Yp >= -1 && Yp <= 1))
			{
				Console.WriteLine("INSIDE Rectangle");
			}
			else
			{
				Console.WriteLine("OUTSIDE Rectangle");
			}
		}


	}
}

