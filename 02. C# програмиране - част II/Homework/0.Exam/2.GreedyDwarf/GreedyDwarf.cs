using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class GreedyDwarf
{

	static int[] ReturnNumbersFromArray(string[] stringArray)
	{
		int[] numberArray = new int[stringArray.Length];
		for (int j = 0; j < stringArray.Length; j++)
		{
			numberArray[j] = int.Parse(stringArray[j]);
		}
		return numberArray;
	}
	static decimal ProcessPatern(int[] valley)
	{
		int[] pattern = ReturnNumbersFromArray(Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries));

		bool[] visitet = new bool[valley.Length];
		decimal coinSum = 0;
		coinSum += valley[0];
		visitet[0] = true;
		int currentPosition = 0;
		while (true)
		{
			for (int i = 0; i < pattern.Length; i++)
			{
				int nextMove = currentPosition + pattern[i];
				if (nextMove >= 0 && nextMove < valley.Length && !visitet[nextMove])
				{
					coinSum += valley[nextMove];
					visitet[nextMove] = true;
					currentPosition = nextMove;
				}
				else
				{
					return coinSum;
				}
			}
		}
	}


	static void Main()
	{
		string[] valleyRaw = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
		int[] valley = ReturnNumbersFromArray(valleyRaw);
		
		int m = int.Parse(Console.ReadLine());
		decimal result = decimal.MinValue;
		for (int i = 0; i < m; i++)
		{
			decimal currentResult = ProcessPatern(valley);
			if(currentResult>=result)
			{
				result = currentResult;
			}
		}
		Console.WriteLine(result);
	}
}
