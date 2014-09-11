/*
 * 12. * Write a recursive program to solve the "8 Queens Puzzle" 
 * with backtracking. Learn more at: http://en.wikipedia.org/wiki/Eight_queens_puzzle
 */

namespace _12.Eight_Queen_Puzzle
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Solution with complexity n! using technique backtracking.
    /// </summary>
    public class EightQueenPuzzle
    {
        private static readonly Stopwatch Sw = new Stopwatch();
        private static readonly int[] QueenCell = new int[BoardSize]; // The queen (i, j)

        // Optimization -> quick check for passable cell
        private static readonly bool[] Columns = new bool[BoardSize] ; // Check if there is queen on that column
        private static readonly bool[] LeftDiagonal = new bool[2 * BoardSize]; // Check if there is queen on that left diagonal
        private static readonly bool[] RightDiagonal = new bool[2 * BoardSize]; // Check if there is queen on that right diagonal

        private static bool isSolutionFound;

        private const int BoardSize = 13;
        private const string QueenSign = "Q";
        private const string EmptyCellSign = ".";

        public static void Main()
        {
            Sw.Start();

            int solutionsCount = 0;
            SolveQueenPuzzle(0, ref solutionsCount, findAllSolutions: true, printSolutions: false);

            Sw.Stop();

            Console.WriteLine("Found {0} solutions.", solutionsCount);
            Console.WriteLine("\nElapsed time: {0}\n", Sw.Elapsed);
        }

        private static void SolveQueenPuzzle(int row, ref int solutionsCount, bool printSolutions = false, bool findAllSolutions = false)
        {
            if (isSolutionFound && !findAllSolutions)
            {
                return;
            }

            if (row == BoardSize)
            {
                solutionsCount++;
                isSolutionFound = true;

                if (printSolutions)
                {
                    PrintChessBoard();
                }
            }

            for (int col = 0; col < BoardSize; col++)
            {
                // Check for passable cell
                if (!Columns[col] && !LeftDiagonal[row + col] && !RightDiagonal[BoardSize + (row - col)])
                {
                    Columns[col] = LeftDiagonal[row + col] = RightDiagonal[BoardSize + (row - col)] = true; // Visited
                    QueenCell[row] = col;

                    SolveQueenPuzzle(row + 1, ref solutionsCount, printSolutions, findAllSolutions);

                    Columns[col] = LeftDiagonal[row + col] = RightDiagonal[BoardSize + (row - col)] = false; // Backtracking
                }
            }
        }

        private static void PrintChessBoard()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    Console.Write("{0,-2} ", QueenCell[i] == j ? QueenSign : EmptyCellSign);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}