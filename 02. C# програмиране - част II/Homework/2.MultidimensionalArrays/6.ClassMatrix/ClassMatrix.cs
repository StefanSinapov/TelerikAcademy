using System;

//* Write a class Matrix, to holds a matrix of integers.
//Overload the operators for adding, subtracting and multiplying of matrices,
//indexer for accessing the matrix content and ToString().

class ClassMatrix
{
	static void Main()
	{
		//int[,] firstMatrix = { 
		//                     {10, 15, 1},
		//                     {50, 17, 3}
		//                     };
		//int[,] secondMatrix = { 
		//                     {11, 18, 5},
		//                     {13, 24, 0}
		//                     };

		Matrix matrix1 = new Matrix(2, 2);

		matrix1[0, 0] = 1;
		matrix1[1, 1] = 12;
		Matrix matrix2 = new Matrix(2, 2);
		matrix2[0, 1] = 5;
		matrix2[1, 1] = 15;

		Matrix sum = matrix1 + matrix2;
		Console.WriteLine(sum.ToString());
	}

	//static void PrintMatrix(Matrix matrix)
	//{
	//    for (int row = 0; row < matrix.Rows; row++)
	//    {
	//        for (int col = 0; col < matrix.Columns; col++)
	//        {
	//            Console.Write(matrix[row,col] + " ");
	//        }
	//        Console.WriteLine();
	//    }
	//}
}
