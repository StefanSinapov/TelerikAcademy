using System;
class CheckIfPositionInBitIsOne
{
	static void Main()
	{
		//Write a boolean expression that returns if the bit at position p (counting from 0) in a given 
		//integer number v has value of 1. Example: v=5; p=1  false.


		int v = int.Parse(Console.ReadLine());
		int p = int.Parse(Console.ReadLine());
		int mask = 1 << p;
		int numberAndMask = v & mask;
		bool result = (numberAndMask >> p)==1;
		Console.WriteLine(result);
	}
}

