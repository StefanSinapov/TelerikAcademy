/*
 * Write a program that reads a rectangular matrix of size N x M
 * and finds in it the square 3 x 3 that has maximal sum of its elements.
 */
using System;
class SquareWithMaxSum
{
	static void Main()
	{
		//Console.Write("Please insert n = ");
		//int n = int.Parse(Console.ReadLine());
		//Console.Write("Please insert m = ");
		//int m = int.Parse(Console.ReadLine());

		const int n = 4; //row
		const int m = 5; //col
		// to be easy to enter whaetever numbers you like I have made it like this, you could add more rows or cols if you want :)
		int[,] matrix = new int[n, m] { { 5, 8, 3, 9, 9 },
                                        { 1, 9, 6, 8, 9 },
                                        { 3, 9, 8, 7, -1000 },
                                        { 500, 2, 10, 1, -2000}
                                      };
		Console.WriteLine("Our matrix looks like:");
		Console.WriteLine();
		for (int row = 0; row < n; row++)
		{
			for (int col = 0; col < m; col++)
			{
				Console.Write("{0,3} ", matrix[row, col]);
			}
			Console.WriteLine();
		}
		Console.WriteLine();
		int maxSum = Int32.MinValue;
		int bestSeqIndexRow = -1;
		int bestSeqIndexCol = -1;
		if (n < 3 || m < 3)
		{
			Console.WriteLine("The values of N and M should be bigger or equal to 3");
		}
		else
		{
			for (int row = 0; row < n - 2; row++) // row goes to n - 2, because the last row that will be reached will include this 2 rows 
			{
				for (int col = 0; col < m - 2; col++) // it goes to m - 2 because of the same reason as the up one
				{
					int tempSum = Int32.MinValue;
					tempSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
							  matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
							  matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2]; // finds the sum of the square 3x3
					if (tempSum > maxSum)
					{
						maxSum = tempSum;
						bestSeqIndexCol = col;
						bestSeqIndexRow = row;
					}
				}
			}
			Console.WriteLine(new string('-', 40));
			Console.WriteLine("The best sum is : {0}", maxSum);
			Console.WriteLine();
			Console.WriteLine("The square 3x3 with best sums is:");

			for (int rows = 0; rows < 3; rows++)
			{
				for (int cols = 0; cols < 3; cols++)
				{
					Console.Write("{0,3} ", matrix[bestSeqIndexRow + rows, bestSeqIndexCol + cols]);
				}
				Console.WriteLine();
			}
		}
	}
}