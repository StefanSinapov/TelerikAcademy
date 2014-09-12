/*
 * Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)﻿
 */
using System;
class FillAndPrintMatrix
{
	static void Main()
	{
		//first type
		Console.Write("Insert the width of the matrix!: ");
		int n = int.Parse(Console.ReadLine());
		Console.WriteLine("The first type of a matrix!");
		int[,] matrixTypeOne = new int[n, n];
		int counter = 1;

		for (int col = 0; col < n; col++)
		{
			for (int row = 0; row < n; row++)
			{
				matrixTypeOne[col, row] = counter;
				counter++;
			}
		}
		counter = 1;
		for (int row = 0; row < n; row++)
		{
			for (int col = 0; col < n; col++)
			{
				Console.Write("{0,2} ", matrixTypeOne[col, row]);
			}
			Console.WriteLine();
		}

		Console.WriteLine(new string('-', 60));
		//second type
		Console.WriteLine("The second type of a matrix!");
		int[,] matrixSecondType = new int[n, n];

		for (int col = 0; col < n; col++)
		{
			if (col % 2 == 0)
			{
				for (int row = 0; row < n; row++)
				{
					matrixSecondType[row, col] = counter;
					counter++;
				}
			}
			else
			{
				for (int row = n - 1; row >= 0; row--)
				{
					matrixSecondType[row, col] = counter;
					counter++;
				}
			}
		}
		for (int row = 0; row < n; row++)
		{
			for (int col = 0; col < n; col++)
			{
				Console.Write("{0,2} ", matrixSecondType[row, col]);
			}
			Console.WriteLine();
		}
		counter = 1;
		Console.WriteLine(new string('-', 60));

		//third type
		Console.WriteLine("The third type of a matrix!");
		int[,] matrixThirdType = new int[n, n];

		int countNumbers = 1;
		int column = 0;
		int roww = n;
		while (countNumbers <= n)
		{
			roww--;
			matrixThirdType[roww, column] = counter;
			counter++;
			for (int i = 1; i < countNumbers; i++)
			{
				roww++;
				column++;
				matrixThirdType[roww, column] = counter;
				counter++;
				if (i == countNumbers - 1)
				{
					roww -= countNumbers - 1;
				}
			}
			countNumbers++;
			column = 0;
		}
		roww = -1;
		column = n - 1;
		counter = n * n;
		countNumbers = 1;

		while (countNumbers < n)
		{
			roww++;
			matrixThirdType[roww, column] = counter;
			counter--;
			for (int i = 1; i < countNumbers; i++)
			{
				roww--;
				column--;
				matrixThirdType[roww, column] = counter;
				counter--;
				if (i == countNumbers - 1)
				{
					roww += countNumbers - 1;
				}
			}
			countNumbers++;
			column = n - 1;
		}

		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < n; j++)
			{
				Console.Write("{0,2} ", matrixThirdType[i, j]);
			}
			Console.WriteLine();
		}
		Console.WriteLine(new string('-', 60));
		// forth type of a matrix
		Console.WriteLine("And the last and most interesting matrix - the spiral one!");
		int[,] arraySpiral = new int[n, n];

		string direction = "down";

		int currentRow = 0;
		int currentCol = 0;

		for (int i = 1; i <= n * n; i++)
		{
			if (direction == "down" && (currentRow >= n || (arraySpiral[currentRow, currentCol] != 0)))
			{
				currentRow--;
				currentCol++;
				direction = "right";
			}
			else if (direction == "right" && (currentCol >= n || (arraySpiral[currentRow, currentCol] != 0)))
			{
				currentCol--;
				currentRow--;
				direction = "up";
			}
			else if (direction == "left" && (currentCol < 0 || (arraySpiral[currentRow, currentCol] != 0)))
			{
				currentCol++;
				currentRow++;
				direction = "down";
			}
			else if (direction == "up" && (currentRow < 0 || (arraySpiral[currentRow, currentCol] != 0)))
			{
				currentRow++;
				currentCol--;
				direction = "left";
			}

			arraySpiral[currentRow, currentCol] = i;

			if (direction == "right")
			{
				currentCol++;
			}
			else if (direction == "down")
			{
				currentRow++;
			}
			else if (direction == "left")
			{
				currentCol--;
			}
			else if (direction == "up")
			{
				currentRow--;
			}
		}
		for (int row = 0; row < n; row++)
		{
			for (int col = 0; col < n; col++)
			{
				Console.Write("{0,2} ", arraySpiral[row, col]);
			}
			Console.WriteLine();
		}
	}
}

