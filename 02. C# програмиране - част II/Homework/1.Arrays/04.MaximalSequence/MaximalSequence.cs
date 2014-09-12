/* Write a program that finds the maximal
 * sequence of equal elements in an array.
                Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.
 */
using System;
class MaximalSequence
{
	static void Main(string[] args)
	{
		int[] array = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };
		int lenght = 1;
		int bestLenght = 0;
		int element=0;
		for (int i = 0; i < array.Length-1; i++)
		{
			if(array[i]==array[i+1])
			{
				lenght++;
			}
			else
			{
				if(lenght>bestLenght)
				{
					bestLenght = lenght;
					element = array[i];
				}
				lenght = 1;
			}
		}

		Console.WriteLine("The longest sequence if form {0} elements of type {1} .", bestLenght, element);
	}
}

