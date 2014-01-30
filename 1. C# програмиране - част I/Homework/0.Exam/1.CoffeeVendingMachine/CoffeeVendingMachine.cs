using System;
class CoffeeVendingMachine
{
	static void Main()
	{
		
		double n1 = double.Parse(Console.ReadLine());
		double n2 = double.Parse(Console.ReadLine());
		double n3 = double.Parse(Console.ReadLine());
		double n4 = double.Parse(Console.ReadLine());
		double n5 = double.Parse(Console.ReadLine());
		double tray=n1*0.05 + n2*0.10 + n3*0.20 + n4*0.50 + n5*1.00;
		double a = double.Parse(Console.ReadLine());
		double p = double.Parse(Console.ReadLine());

		if (a>=p && tray>=a-p)
		{
			Console.WriteLine("Yes {0:0.00}",tray-(a-p));
		}
		else if (a >= p && tray < (a - p))
		{
			Console.WriteLine("No {0:0.00}", (a - p)-tray);
		}
		else if(a<p)
		{
			Console.WriteLine("More {0:f2}",p-a);
		}

		
	}
}

		
