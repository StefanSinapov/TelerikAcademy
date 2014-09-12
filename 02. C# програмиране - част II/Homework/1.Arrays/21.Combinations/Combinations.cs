using System;

class Combinations
{
	static void Main()
	{
		Console.Write("Enter the number of elements:");
		long numberOfElements = long.Parse(Console.ReadLine());
		Console.Write("Enter K:");
		long K = long.Parse(Console.ReadLine());
		long[] elements = new long[numberOfElements];
		string subset = "";
		int lenCounter = 0;

		for (int i = 1; i <= elements.Length; i++)
		{
			elements[i - 1] = i;
		}
		//for (int i = 0; i < elements.Length; i++)
		//{
		//	Console.Write("Enter element № {0}", i + 1);
		//	elements[i] = long.Parse(Console.ReadLine());
		//}
		int maxSubsets = (int)Math.Pow(2, numberOfElements);
		for (int i = 1; i < maxSubsets; i++)
		{
			subset = "";
			for (int j = 0; j <= numberOfElements; j++)
			{
				int mask = 1 << j;
				int nAndMask = i & mask;
				int bit = nAndMask >> j;
				if (bit == 1)
				{
					subset = subset + " " + elements[j];
					lenCounter++;
				}
			}
			if (lenCounter == K)
			{
				Console.WriteLine(subset);
			}
			lenCounter = 0;
		}
	}
}