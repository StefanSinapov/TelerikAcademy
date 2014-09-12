using System;
using System.Collections.Generic;

class SortStringByLength
{
	//You are given an array of strings.
	//Write a method that sorts the array by the length of its elements (the number of characters composing them).

	static void Main()
	{
		string[] arr = { "abcde", "ab", "abcdefgh", "abcd", "a", "abcdeserwe", "djvdjvdjvdjvdjv", "ada", "obichamBob" };
		Console.WriteLine("Unsorted array:\n {0}", String.Join(", ", arr));
		Console.WriteLine();

		int counter = 0;
		int arrSortedIndex = 0;
		string[] arrSorted = new string[arr.Length];

		while (arrSorted[arrSorted.Length - 1] == null)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i].Length == counter)
				{
					arrSorted[arrSortedIndex] = arr[i];
					arrSortedIndex++;
				}
			}
			counter++;
		}
		Console.WriteLine("Sorted array:\n {0}", String.Join(", ", arrSorted));
		Console.WriteLine();
	}
}
