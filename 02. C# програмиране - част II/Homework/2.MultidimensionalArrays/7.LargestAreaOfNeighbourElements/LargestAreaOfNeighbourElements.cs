using System;
using System.Collections.Generic;

//* Write a program that finds the largest area of equal neighbor elements in a rectangular matrix and prints its size.
//Hint: you can use the algorithm "Depth-first search" or "Breadth-first search" (find them in Wikipedia).

class LargestAreaOfNeighbourElem
{
	static int counter = 0;

	static int[,] directions = 
    {
        {-1 , 0 },
        { 1 , 0 },
        { 0 , -1},
        { 0 , 1 }
    };

	static void TraverseBFS(int[,] arr, bool[,] boolArr, int row, int col)
	{
		Queue<int> queue = new Queue<int>();
		if (!boolArr[row, col])
		{
			queue.Enqueue(arr[row, col]);
			while (queue.Count > 0)
			{
				int currentNode = queue.Dequeue();
				counter++;
				boolArr[row, col] = true;
				bool downward = false;
				bool upward = false;
				bool left = false;
				bool right = false;
				for (int i = 0; i < 4; i++)
				{
					if (((row - 1) >= 0) && (!boolArr[row - 1, col]) && (arr[row - 1, col] == arr[row, col]) && !upward)
					{
						queue.Enqueue(arr[row - 1, col]);
						upward = true;
					}
					else if (((col - 1) >= 0) && (!boolArr[row, col - 1]) && (arr[row, col - 1] == arr[row, col]) && !left)
					{
						queue.Enqueue(arr[row, col - 1]);
						left = true;
					}
					else if (((col + 1) <= arr.GetLength(0)) && (!boolArr[row, col + 1]) && (arr[row, col + 1] == arr[row, col]) && !right)
					{
						queue.Enqueue(arr[row, col + 1]);
						right = true;
					}
					else if (((row + 1) <= arr.GetLength(1)) && (!boolArr[row + 1, col]) && (arr[row + 1, col] == arr[row, col]) && !downward)
					{
						queue.Enqueue(arr[row + 1, col]);
						downward = true;
					}

				}

			}
		}
	}

	static void Main()
	{
		int[,] arr =
        {
            { 1, 3, 2, 2, 2, 4},
            { 3, 3, 3, 2, 4, 4},
            { 4, 3, 1, 2, 3, 3},
            { 4, 3, 1, 3, 3, 1},
            { 4, 3, 3, 3, 1, 1},
        };
		bool[,] boolArr = new bool[arr.GetLength(0), arr.GetLength(1)];
		for (int row = 0; row < arr.GetLength(1); row++)
		{
			for (int col = 0; col < arr.GetLength(0); col++)
			{
				TraverseBFS(arr, boolArr, row, col);
				Console.WriteLine(counter);
				counter = 0;
			}
		}
	}
}