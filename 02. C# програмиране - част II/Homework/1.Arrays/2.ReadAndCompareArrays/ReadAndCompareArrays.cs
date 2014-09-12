/*
 * Write a program that reads two arrays from the console and compares them element by element.
 */
using System;
class ReadAndCompareArrays
{
	static void Main()
	{
		//read the lenght of the arrays
		Console.Write("Elements in first array: ");
		int firstArrayLenght = int.Parse(Console.ReadLine());
		Console.Write("Elements in second array: ");
		int secondArrayLenght = int.Parse(Console.ReadLine());

		int[] firstArray=new int[firstArrayLenght];
		int[] secondArray = new int[secondArrayLenght];

		//read the arrays
		Console.WriteLine("First Array");
		for (int i = 0; i < firstArray.Length; i++)
		{
			Console.Write("element[{0}]= ",i);
			firstArray[i] = int.Parse(Console.ReadLine());
		}
		Console.WriteLine("Second Array");
		for (int i = 0; i < secondArray.Length; i++)
		{
			Console.Write("element[{0}]= ",i);
			secondArray[i] = int.Parse(Console.ReadLine());
		}

		//compare (print only elements that are same in both arrays)
		for (int i = 0; i < firstArray.Length; i++)
		{
			for (int j = 0; j < secondArray.Length; j++)
			{
				if (firstArray[i]==secondArray[j])
				{
					Console.WriteLine("first array element[{0}] = second array element[{1}] = {2} ",i,j,firstArray[i]);
				}
			}
		}

	}
}

