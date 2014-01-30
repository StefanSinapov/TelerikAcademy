/* Write a program that finds the index of 
 * given element in a sorted array of integers 
 * by using the binary search algorithm (find it in Wikipedia).
 */

using System;

class BinarySearch
{
	static int BinSearch(int[] array, int key)
	{
		Array.Sort(array);
		int iMax = array.Length - 1;
		int iMin = 0;
		while (iMax >= iMin)
		{
			int iMidpoint = (iMin + iMax) / 2;
			if (array[iMidpoint] < key)
			{
				iMin = iMidpoint + 1;
			}
			else if (array[iMidpoint] > key)
			{
				iMax = iMidpoint - 1;
			}
			else
			{
				return iMidpoint;
			}
		}
		return -1;
	}
	static void Main()
	{
		int[] myArray = { 4, 3, 1, 4, 2, 5, 8, 21, 13, 180 };
		int key = 8;
		Console.WriteLine(BinSearch(myArray, key));
	}
}