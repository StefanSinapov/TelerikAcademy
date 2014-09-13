namespace _02._3d_Labyrint
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Labyrinth
    {
        private static int levels;
        private static int rows;
        private static int cols;
        private static char[, ,] labyrinth;
        static void Main()
        {

#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var startingCell = new Cell<int>
            {
                Level = input[0],
                Row = input[1],
                Col = input[2]
            };

            var secondLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            levels = secondLine[0];
            rows = secondLine[1];
            cols = secondLine[2];

            labyrinth = new char[levels, rows, cols];

            for (int i = 0; i < levels; i++)
            {

                for (int j = 0; j < rows; j++)
                {
                    var line = Console.ReadLine().Trim();
                    for (int k = 0; k < line.Length; k++)
                    {
                        labyrinth[i, j, k] = line[k];
                    }
                }
            }

            Bfs(startingCell);
        }

        private static readonly Queue<Cell<int>> queue = new Queue<Cell<int>>();
        private static readonly HashSet<Cell<int>> usedCells = new HashSet<Cell<int>>();


        private static void Bfs(Cell<int> cell)
        {
            VisitCell(cell, 0, 0, 0);

            while (queue.Count > 0)
            {
                cell = queue.Dequeue();

                if (0 <= cell.Level && cell.Level < levels)
                {
                    VisitCell(cell, 0, 1); //right
                    VisitCell(cell, 0, -1); //left
                    VisitCell(cell, 1, 0); //down
                    VisitCell(cell, -1, 0); //up
                }
                else
                {
                    Console.WriteLine("{0}", cell.Distance);
                    return;
                }
            }
        }

        private static void VisitCell(Cell<int> cell, int row, int col, int distance = 1)
        {
            var newCell = new Cell<int>
            {
                Row = cell.Row + row,
                Col = cell.Col + col,
                Level = cell.Level,
                Distance = cell.Distance + distance
            };

            if (usedCells.Contains(newCell))
            {
                return;
            }


            if (newCell.Row < 0 || newCell.Col < 0 || newCell.Col >= labyrinth.GetLongLength(2) ||
                newCell.Row >= labyrinth.GetLongLength(1) || newCell.Level < 0
                || newCell.Level >= labyrinth.GetLongLength(0))
            {
                usedCells.Add(newCell);
                return;
            }

            if (labyrinth[newCell.Level, newCell.Row, newCell.Col] == '.')
            {
                queue.Enqueue(newCell);
            }
            else if (labyrinth[newCell.Level, newCell.Row, newCell.Col] == 'D')
            {
                newCell.Level--;
                newCell.Distance++;
                queue.Enqueue(newCell);

            }
            else if (labyrinth[newCell.Level, newCell.Row, newCell.Col] == 'U')
            {
                newCell.Level++;
                newCell.Distance++;
                queue.Enqueue(newCell);
            }

            usedCells.Add(newCell);
        }
    }

    public class Cell<T>
    {
        public Cell()
        {

        }
        public Cell(T row, T col, T level)
        {
            Row = row;
            Col = col;
            Level = level;
        }

        public T Row { get; set; }

        public T Col { get; set; }

        public T Level { get; set; }

        public T Distance { get; set; }

        public override bool Equals(object obj)
        {
            var otherCell = obj as Cell<T>;
            if (otherCell == null)
            {
                return false;
            }

            return this.Row.Equals(otherCell.Row) && this.Col.Equals(otherCell.Col);
        }

        public override int GetHashCode()
        {
            return this.Level.GetHashCode() ^
                   this.Row.GetHashCode() ^
                   this.Col.GetHashCode();
        }
    }
}
