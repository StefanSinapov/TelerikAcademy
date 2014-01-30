/* 14. * Write a program that reads a positive integer number N (N < 20) 
 * from console and outputs in the console the numbers 1 ... N numbers arranged as a spiral.
 *  1  2  3  4
 * 	12 13 14 5
 * 	11 16 15 6
 * 	10 9  8  7
 */
using System;
class SpiralMatrix
{
	static void Main()
	{
		byte matrixSize;
		for (; ; )
		{
			Console.Write("Enter matrix size N (where N x N and 3 <= N < 20): ");
			matrixSize = byte.Parse(Console.ReadLine());

			if (matrixSize >= 3 && matrixSize < 20)
			{
				break;
			}
			else
			{
				Console.WriteLine("Error: N is not between 3 (including) and 20!\n");
			}
		}

		short[,] matrix = new short[matrixSize, matrixSize];
		short firstIndex = 0, secondIndex = 0, currentSize = matrixSize, ct = 1;

		while (ct <= (matrixSize * matrixSize))
		{
			short referencePoint = firstIndex; // or second, doesn't matter

			if (currentSize > 1)
			{
				// 2nd index +1 
				while (secondIndex < currentSize)
				{
					matrix[firstIndex, secondIndex] = ct;
					secondIndex++;
					ct++;
				}
				secondIndex--;

				// 1st index +1
				firstIndex++;
				while (firstIndex < currentSize)
				{
					matrix[firstIndex, secondIndex] = ct;
					firstIndex++;
					ct++;
				}
				firstIndex--;

				// 2nd index -1
				secondIndex--;
				while (secondIndex >= referencePoint)
				{
					matrix[firstIndex, secondIndex] = ct;
					secondIndex--;
					ct++;
				}
				secondIndex++;

				// 1st index -1
				firstIndex--;
				while (firstIndex > referencePoint)
				{
					matrix[firstIndex, secondIndex] = ct;
					firstIndex--;
					ct++;
				}
			}
			else
			{
				matrix[firstIndex, currentSize] = ct;
				ct++;
			}

			// Update ...
			firstIndex++;
			secondIndex++;
			currentSize -= 1;
		}

		Console.WriteLine(Environment.NewLine);

		// Now print it ...
		for (int i = 0; i < matrixSize; i++)
		{
			for (int j = 0; j < matrixSize; j++)
			{
				Console.Write("{0,3} ", matrix[i, j]);
			}

			Console.WriteLine();
		}
	}
}

