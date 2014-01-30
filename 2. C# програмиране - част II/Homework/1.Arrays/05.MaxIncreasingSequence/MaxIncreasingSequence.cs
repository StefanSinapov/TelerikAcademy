/* Write a program that finds the maximal
 * increasing sequence in an array. Example: 
 * {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.
 */
using System;
class MaxIncreasingSequence
{
	static void Main(string[] args)
	{
		int[] myArray = { 3, 2, 3, 4, 2, 2, 4 };
		int lenght = 1;
		int bestLenght = 0;
		int lastIndex = 0;
		for (int i = 0; i < myArray.Length - 1; i++)
		{
			if (myArray[i] == myArray[i + 1]-1)
			{
				lenght++;
			}
			else
			{
				if (lenght > bestLenght)
				{
					bestLenght = lenght;
					lastIndex = i;
				}
				lenght = 1;
			}
		}

		//print
		Console.Write("the best increasing sequence is: {");
		for (int i = lastIndex-bestLenght+1; i <= lastIndex; i++)
		{
			Console.Write((myArray[i]) + " ");
		}
		Console.WriteLine("}");

	}
}
