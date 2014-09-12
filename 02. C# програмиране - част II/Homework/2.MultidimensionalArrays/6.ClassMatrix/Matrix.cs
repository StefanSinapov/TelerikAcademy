using System;

class Matrix
{
	private int[,] matrix;

	//makes the matrix to be a multidimensional array with 2 dimensions ( int[,] )
	public Matrix(int rows, int cols)
	{
		this.matrix = new int[rows, cols];

	}

	//getting the rows of the matrix
	public int Rows
	{
		get
		{
			return this.matrix.GetLength(0);
		}
	}

	//getting the columns of the matrix
	public int Columns
	{
		get
		{
			return this.matrix.GetLength(1);
		}
	}

	//operator +
	public static Matrix operator +(Matrix first, Matrix second)
	{
		Matrix result = new Matrix(first.Rows, first.Columns);

		for (int row = 0; row < first.Rows; row++)
		{
			for (int col = 0; col < first.Columns; col++)
			{
				result[row, col] = first[row, col] + second[row, col];
			}
		}
		return result;
	}

	//indexer
	public int this[int row, int col]
	{
		get
		{
			return this.matrix[row, col];
		}

		set
		{
			this.matrix[row, col] = value;
		}
	}

	public override string ToString()
	{
		string result = null;

		for (int row = 0; row < this.Rows; row++)
		{
			for (int col = 0; col < this.Columns; col++)
			{
				result += matrix[row, col] + " ";
			}
			result += Environment.NewLine;
		}
		return result;
	}
}