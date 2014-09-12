/* Sorting an array means to arrange
 * its elements in increasing order.
 * Write a program to sort an array.
 * Use the "selection sort" algorithm:
 * Find the smallest element, move it at the
 * first position, find the smallest from the
 * rest, move it at the second position, etc.
 */

using System;

class SelectSort
{
	static void Main()
	{
		int[] myArray = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 11, 132, 45, -2, 333 };
		for (int i = 0; i < myArray.Length - 1; i++)
		{
			int minElement = i;
			for (int j = i + 1; j < myArray.Length; j++)
			{
				if (myArray[j] < myArray[minElement])
				{
					minElement = j;
				}
			}
			if (minElement != i)
			{
				int temp = 0;
				temp = myArray[i];
				myArray[i] = myArray[minElement];
				myArray[minElement] = temp;
			}
		}
		for (int i = 0; i < myArray.Length; i++)
		{
			Console.Write("{0}, ", myArray[i]);
		}
		Console.WriteLine();
	}
}