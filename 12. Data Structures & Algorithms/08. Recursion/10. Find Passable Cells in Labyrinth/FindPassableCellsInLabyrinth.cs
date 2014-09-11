/*
 * 10. * We are given a matrix of passable and non-passable cells. 
 * Write a recursive program for finding all areas of passable cells in the matrix.
 */

namespace _10.Find_Passable_Cells_in_Labyrinth
{
    using System;
    using System.Collections.Generic;

    public class FindPassableCellsInLabyrinth
    {
        // Passable cell is marked with "x"
        private static readonly string[,] Matrix =
        {
            { "1", "x", "2", "2", "2", "x" },
            { "x", "x", "x", "2", "4", "x" },
            { "4", "x", "1", "2", "x", "x" },
            { "4", "x", "1", "2", "1", "1" },
            { "4", "x", "1", "x", "x", "x" }
        };

        private const string VisitedCell = "";
        private const string PassableCell = "x";

        public static void Main()
        {
            PrintMatrix();

            var allPassableAreas = FindAllConnectedAreas();

            Console.WriteLine("\nAll passable areas: \n");
            Console.WriteLine(string.Join(Environment.NewLine, allPassableAreas) + Environment.NewLine);
        }

        private static IEnumerable<string> FindAllConnectedAreas()
        {
            var allPassableAreas = new List<string>();
            var currentArea = new List<string>();

            for (int i = 0; i < Matrix.GetLongLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLongLength(1); j++)
                {
                    currentArea.Clear();

                    FindAreaDfs(i, j, currentArea);

                    if (currentArea.Count > 0)
                    {
                        allPassableAreas.Add(string.Format("{0} -> Length: {1}", string.Join(" -> ", currentArea), currentArea.Count));
                    }
                }
            }

            return allPassableAreas;
        }

        private static void FindAreaDfs(int row, int col, IList<string> areaPath)
        {
            var isNonPassableCell = row < 0 || row >= Matrix.GetLongLength(0) ||
                                    col < 0 || col >= Matrix.GetLongLength(1) ||
                                    Matrix[row, col] != PassableCell;

            if (isNonPassableCell)
            {
                return;
            }

            areaPath.Add(string.Format("({0},{1})", row, col));
            Matrix[row, col] = VisitedCell; 

            FindAreaDfs(row, col - 1, areaPath);
            FindAreaDfs(row, col + 1, areaPath);
            FindAreaDfs(row - 1, col, areaPath);
            FindAreaDfs(row + 1, col, areaPath);
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