using System;
using System.Collections.Generic;

class ElementsRemove
{
	static bool AreSorted(List<long> array)
	{
		bool isSorted = true;
		for (int i = 0; i < array.Count - 1; i++)
		{
			if (!(array[i] <= array[i + 1]))
			{
				isSorted = false;
			}
		}
		return isSorted;
	}
	static void Main()
	{
		//Console.WriteLine("Enter the number of elements:");
		//long numberOfElements = long.Parse(Console.ReadLine());
		//long[] elements = new long[numberOfElements];
		long[] elements = { 6, 1, 4, 3, 0, 3, 6, 4, 5 };
		//for (int i = 0; i < elements.Length; i++)
		//{
		//    Console.WriteLine("Enter element № {0}", i + 1);
		//    elements[i] = long.Parse(Console.ReadLine());
		//}
		int len = 0;
		int bestLen = 0;
		List<long> bestResult = new List<long>();
		int maxSubsets = (int)Math.Pow(2, elements.Length);
		for (int i = 1; i < maxSubsets; i++)
		{
			List<long> result = new List<long>();

			for (int j = 0; j <= elements.Length; j++)
			{
				int mask = 1 << j;
				int nAndMask = i & mask;
				int bit = nAndMask >> j;
				if (bit == 1)
				{
					result.Add(elements[j]);
					len++;
				}
			}
			if (AreSorted(result))
			{
				if (len > bestLen)
				{
					bestLen = len;
					bestResult = result;
				}
			}
			len = 0;
			//if (checkingSum == wantedSum)
			//{
			//    Console.WriteLine("Number of subest that have the sum of {0}", wantedSum);
			//    counter++;
			//    Console.WriteLine("This subset has a sum of {0} : {1} ", wantedSum, subset);
			//}
		}
		foreach (var item in bestResult)
		{
			Console.Write("{0} ", item);
		}
	}
}