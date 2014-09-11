/*
 * 9. Write a recursive program to find the largest connected
 * area of adjacent empty cells in a matrix.
 */

namespace _09.Longest_Path_in_Labyrinth
{
    using System;

    public class LargestConnectedArea
    {
        // Passable cell is marked with "x"
        private static readonly string[,] Matrix =
        {
            { "1", "x", "2", "2", "2", "x" },
            { "x", "x", "x", "2", "4", "x" },
            { "4", "x", "1", "2", "x", "x" },
            { "4", "x", "1", "2", "x", "1" },
            { "4", "x", "1", "x", "x", "x" }
        };

        private const string VisitedCell = "";
        private const string PassableCell = "x";

        public static void Main()
        {
            PrintMatrix();

            var bestLength = FindLargestConnectedArea();

            Console.WriteLine("\nBest area: {0}\n",
                bestLength != 0 ? string.Format("{0} -> {1} time(s).", PassableCell, bestLength) : "There is no best area.");
        }

        private static int FindLargestConnectedArea()
        {
            int bestLength = int.MinValue;

            for (int i = 0; i < Matrix.GetLongLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLongLength(1); j++)
                {
                    var currentLength = 0;

                    FindAreaDfs(i, j, ref currentLength);

                    if (currentLength > bestLength)
                    {
                        bestLength = currentLength;
                    }
                }
            }

            return bestLength;
        }

        private static void FindAreaDfs(int row, int col, ref int currentLength)
        {
            var isNonPassableCell = row < 0 || row >= Matrix.GetLongLength(0) ||
                                    col < 0 || col >= Matrix.GetLongLength(1) ||
                                    Matrix[row, col] != PassableCell;

            if (isNonPassableCell)
            {
                return;
            }

            currentLength++;
            Matrix[row, col] = VisitedCell;

            FindAreaDfs(row, col - 1, ref currentLength);
            FindAreaDfs(row, col + 1, ref currentLength);
            FindAreaDfs(row - 1, col, ref currentLength);
            FindAreaDfs(row + 1, col, ref currentLength);
        }

        private static void PrintMatrix()
        {
            for (int i = 0; i < Matrix.GetLongLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLongLength(1); j++)
                {
                    Console.Write("{0,-3}", Matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}