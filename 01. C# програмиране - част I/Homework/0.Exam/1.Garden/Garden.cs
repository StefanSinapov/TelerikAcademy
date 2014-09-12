using System;
class Garden
{
	static void Main()
	{
		int area = 250;
		int tomatoSeed = int.Parse(Console.ReadLine());
		int tomatoArea = int.Parse(Console.ReadLine());
		int cucumberSeed = int.Parse(Console.ReadLine());
		int cucumberArea = int.Parse(Console.ReadLine());
		int potatoSeed = int.Parse(Console.ReadLine());
		int potatoArea = int.Parse(Console.ReadLine());
		int carrotSeed = int.Parse(Console.ReadLine());
		int carrotArea = int.Parse(Console.ReadLine());
		int cabbageSeed = int.Parse(Console.ReadLine());
		int cabbageArea = int.Parse(Console.ReadLine());
		int beanSeed = int.Parse(Console.ReadLine());

		double totalCosts = (tomatoSeed * 0.5) + (cucumberSeed * 0.4) + (potatoSeed * 0.25) + (carrotSeed * 0.6) + (cabbageSeed * 0.3) + (beanSeed * 0.4);
		int beansArea = area - tomatoArea - cucumberArea - potatoArea - carrotArea - cabbageArea;

		Console.WriteLine("Total costs: {0:0.00}",totalCosts);

		if (beansArea>0)
		{
			Console.WriteLine("Beans area: {0}",beansArea);
		}
		else if (beansArea==0)
		{
			Console.WriteLine("No area for beans");
		}
		else if(beansArea<0)
		{
			Console.WriteLine("Insufficient area");
		}

	}
}

