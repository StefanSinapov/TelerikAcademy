/*
 * 7. We are given a matrix of passable and 
 * non-passable cells.
 * Write a recursive program for finding all 
 * paths between two cells in the matrix.
 */
namespace _07.All_Paths_in_Labyrinth
{
    using System;
    using System.Collections.Generic;

    class AllPathsInLabyrinth
    {
        static void Main()
        {
            FindAllPaths(0, 0, ' ');
            Console.WriteLine("All paths in labyrinth are: {0}", pathsCount);
        }

        static readonly char[,] Lab =
                                    {
                                          {' ', ' ', ' ', '*', ' ', ' ', ' '},
                                          {'*', '*', ' ', '*', ' ', '*', ' '},
                                          {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                          {' ', '*', '*', '*', '*', '*', ' '},
                                          {' ', ' ', ' ', ' ', ' ', ' ', 'е'}
                                    };

        static readonly char[] Path = new char[Lab.GetLength(0) * Lab.GetLength(1)];
        static int position;
        private static int pathsCount = 0;

        static void FindAllPaths(int row, int col, char direction)
        {
            if ((col < 0) || (row < 0) ||
                  (col >= Lab.GetLength(1)) || (row >= Lab.GetLength(0)))
            {
                // We are out of the labyrinth
                return;
            }

            // Append the direction to the path
            Path[position] = direction;
            position++;

            // Check if we have found the exit
            if (Lab[row, col] == 'е')
            {
                PrintPath(Path, 1, position - 1);
               
            }

            if (Lab[row, col] == ' ')
            {
                // The current cell is free. Mark it as visited
                Lab[row, col] = 's';

                // Invoke recursion to explore all possible directions
                FindAllPaths(row, col - 1, 'L'); // left
                FindAllPaths(row - 1, col, 'U'); // up
                FindAllPaths(row, col + 1, 'R'); // right
                FindAllPaths(row + 1, col, 'D'); // down

                // Mark back the current cell as free
                Lab[row, col] = ' ';
            }

            // Remove the direction from the path
            position--;
        }

        static void PrintPath(IList<char> path, int startPos, int endPos)
        {
            Console.Write("Found path {0} to the exit: ",  ++pathsCount);
            for (int pos = startPos; pos <= endPos; pos++)
            {
                Console.Write(path[pos]);
            }
            Console.WriteLine();
        }
    }


}
