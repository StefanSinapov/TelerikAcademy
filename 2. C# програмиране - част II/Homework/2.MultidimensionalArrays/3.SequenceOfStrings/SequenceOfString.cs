/*
 * We are given a matrix of strings of size N x M.
 * Sequences in the matrix we define as sets of several neighbor elements located on the same line, column or diagonal.
 * Write a program that finds the longest sequence of equal strings in the matrix. 
 */
using System;
class LongestSeqOfStrings
{
	static void Main()
	{
		const int n = 4; //row
		const int m = 5; //col
		// to be easy to enter whaetever numbers you like I have made it like this, you could add more rows or cols if you want :)
		Console.WriteLine("The matrix looks like:");
		string[,] matrix = new string[n, m] { { "eh", "ha", "ha", "ho", "fo" },
                                              { "fu", "wh", "ho", "hi", "fo" },
                                              { "ad", "ho", "djv", "hi", "se" },
                                              { "ho", "too", "ej", "hi", "djv" }
                                            };
		for (int row = 0; row < n; row++)
		{
			for (int col = 0; col < m; col++)
			{
				Console.Write("{0,4} ", matrix[row, col]);
			}
			Console.WriteLine();
		}
		Console.WriteLine();
		int bestSequence = 1; // it starts from 1 because every string will be best sequence if there isn't two which are equal and next to each other
		string BestSeqWord = "";
		for (int row = 0; row < n; row++)
		{
			for (int col = 0; col < m; col++)
			{
				int tempSeq = 1;

				for (int i = col + 1; i < m; i++) // checks until the end of the row if there is a sequence
				{
					if (matrix[row, col] == matrix[row, i])
					{
						tempSeq++;
					}
				}
				if (tempSeq > bestSequence)
				{
					BestSeqWord = matrix[row, col];
					bestSequence = tempSeq;
				}
				tempSeq = 1;
				for (int j = row + 1; j < n; j++) // checks until the end of the col if there is a sequence
				{
					if (matrix[row, col] == matrix[j, col])
					{
						tempSeq++;
					}
				}
				if (tempSeq > bestSequence)
				{
					bestSequence = tempSeq;
					BestSeqWord = matrix[row, col];
				}
				tempSeq = 1;
				for (int k = 1; k < n; k++) // checks if there is a sequence in the diagonal 
				{
					if ((row + k >= n) || (col + k >= n))
					{
						break;
					}
					if (matrix[row, col] == matrix[row + k, col + k])
					{
						tempSeq++;
					}
				}
				if (tempSeq > bestSequence)
				{
					bestSequence = tempSeq;
					BestSeqWord = matrix[row, col];
				}
			}
		}
		Console.WriteLine(new string('-', 40));
		if (bestSequence > 1)
		{
			Console.WriteLine("The best sequence is: {0}", bestSequence);
			Console.Write("The sequence is: ");
			for (int i = 0; i < bestSequence; i++)
			{
				Console.Write("{0} ", BestSeqWord);
			}
			Console.WriteLine();
		}
		else
		{
			Console.WriteLine("There isn't any sequence!");
		}
	}
}
