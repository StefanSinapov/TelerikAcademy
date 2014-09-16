namespace _01.Portals
{
    using System;
    using System.Linq;

    class PortalsDemo
    {
        private static int bestResult = 0;
        private static int[,] matrix;
        public static int maxRows;
        public static int maxCols;

        static void Main()
        {

#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

            var numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var startingCell = new Cell(numbers[0], numbers[1]);

            var dimentions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            maxRows = dimentions[0];
            maxCols = dimentions[1];

            matrix = new int[maxRows, maxCols];

            for (int i = 0; i < maxRows; i++)
            {
                string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < maxCols; j++)
                {
                    var value = tokens[j];

                    if (value == "#")
                    {
                        matrix[i, j] = -1;
                    }
                    else
                    {
                        var parsedvalue = int.Parse(value);

                        matrix[i, j] = parsedvalue;
                    }
                }
            }

            Solve(startingCell, 0, 0, 0, 0);

            Console.WriteLine(bestResult);
        }

        public static void Solve(Cell cell, int rows, int cols, int currentBest, int value)
        {
            cell.X += rows;
            cell.Y += cols;


            if (cell.X < 0 || cell.X >= maxRows || cell.Y < 0 || cell.Y >= maxCols)
            {
                if (currentBest > bestResult)
                {
                    bestResult = currentBest;
                }
                return;
            }

            currentBest += value;


            if (matrix[cell.X, cell.Y] == -1)
            {
                if (currentBest > bestResult)
                {
                    bestResult = currentBest;
                }
                return;
            }


            var cellValue = matrix[cell.X, cell.Y];


            matrix[cell.X, cell.Y] = -1;

            if (cellValue >= maxCols && cellValue >= maxRows)
            {
                currentBest = cellValue;
            }

            Solve(cell, cellValue, 0, currentBest, cellValue); //down
            Solve(cell, -cellValue, 0, currentBest, cellValue); //up
            Solve(cell, 0, cellValue, currentBest, cellValue); //right
            Solve(cell, 0, -cellValue, currentBest, cellValue); //left

            matrix[cell.X, cell.Y] = cellValue;
        }

        /*
         dfs
         * if(outofmatrix)
         * {
         * return
         * }
         * 
         * 
         * if(-1)
         * {return;}
         * 
         * 
         * cellValue = matrix[x, y]
         * matrix[x,y] = -1
         * dfs
         * matrix[x,y] = cellValue;
         * 
         */

        public struct Cell
        {
            public Cell(int x, int y)
                : this()
            {
                X = x;
                Y = y;
            }

            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}
