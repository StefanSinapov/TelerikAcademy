using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth3D
{
    struct Position
    {
        public int Level;
        public int Row;
        public int Col;

        public Position(int level, int row, int col)
        {
            this.Level = level;
            this.Row = row;
            this.Col = col;
        }

        public static Position Parse(string s)
        {
            string[] coordinateStrings = s.Split(' ');

            return new Position(int.Parse(coordinateStrings[0]),
                int.Parse(coordinateStrings[1]),
                int.Parse(coordinateStrings[2])
                );
        }

        public override bool Equals(object obj)
        {
            try
            {
                Position objAsPosition = (Position)obj;
                return this.Level == objAsPosition.Level && this.Row == objAsPosition.Row && this.Col == objAsPosition.Col;
            }
            catch (InvalidCastException)
            {
                return false;
            }
        }

        public override string ToString()
        {
            return this.Level + " " + this.Row + " " + this.Col;
        }
    }

    class Labyrinth3D
    {
        const char LadderUp = 'U';
        const char LadderDown = 'D';
        const char Impassable = '#';
        const char Free = '.';

        static void Main(string[] args)
        {
            Position startPosition = Position.Parse(Console.ReadLine());

            char[, ,] labyrinth = InitializeLabyrinthFromInput();

            int escapeLength = GetBfsEscapeLength(labyrinth, startPosition);

            Console.WriteLine(escapeLength);
        }

        private static int GetBfsEscapeLength(char[, ,] labyrinth, Position startPosition)
        {
            int levelsCount = labyrinth.GetLength(0),
                rowsCount = labyrinth.GetLength(1),
                colsCount = labyrinth.GetLength(2);

            Position[, ,] predecessors = new Position[levelsCount, rowsCount, colsCount];

            Queue<Position> toVisit = new Queue<Position>();
            toVisit.Enqueue(startPosition);

            Position currentPosition;

            bool exitFound = false;

            do
            {
                currentPosition = toVisit.Dequeue();
                //visited[currentPosition.Level, currentPosition.Row, currentPosition.Col] = true;

                List<Position> neighborPositions = GetNeighborPositions(currentPosition, labyrinth);

                labyrinth[currentPosition.Level, currentPosition.Row, currentPosition.Col] = Impassable;

                foreach (var position in neighborPositions)
                {
                    if (!IsEscapePosition(position, levelsCount, rowsCount, colsCount))
                    {
                        toVisit.Enqueue(position);
                        predecessors[position.Level, position.Row, position.Col] = currentPosition;
                    }
                    else
                    {
                        exitFound = true;
                    }
                }
            }
            while (!exitFound && toVisit.Count > 0);

            int escapeLength = 1;
            Position backTrackPosition = currentPosition;
            while (!backTrackPosition.Equals(startPosition))
            {
                backTrackPosition = predecessors[backTrackPosition.Level, backTrackPosition.Row, backTrackPosition.Col];
                escapeLength++;
            }

            return escapeLength;
        }

        private static bool IsEscapePosition(Position currentPosition, int levelsCount, int rowsCount, int colsCount)
        {
            if (currentPosition.Level < 0 || currentPosition.Level >= levelsCount)
            {
                if (currentPosition.Row >= 0 && currentPosition.Row < rowsCount &&
                    currentPosition.Col >= 0 && currentPosition.Col < colsCount)
                {
                    return true;
                }
            }

            return false;
        }

        private static List<Position> GetNeighborPositions(Position currentPosition, char[, ,] labyrinth)
        {
            int levelsCount = labyrinth.GetLength(0),
                rowsCount = labyrinth.GetLength(1),
                colsCount = labyrinth.GetLength(2);

            List<Position> neighborPositions = new List<Position>();

            if (IsInLabyrinth(currentPosition, levelsCount, rowsCount, colsCount))
            {
                neighborPositions.Add(new Position(currentPosition.Level, currentPosition.Row + 1, currentPosition.Col));
                neighborPositions.Add(new Position(currentPosition.Level, currentPosition.Row, currentPosition.Col + 1));
                neighborPositions.Add(new Position(currentPosition.Level, currentPosition.Row - 1, currentPosition.Col));
                neighborPositions.Add(new Position(currentPosition.Level, currentPosition.Row, currentPosition.Col - 1));

                if (labyrinth[currentPosition.Level, currentPosition.Row, currentPosition.Col] == LadderUp)
                {
                    neighborPositions.Add(new Position(currentPosition.Level + 1, currentPosition.Row, currentPosition.Col));
                }

                if (labyrinth[currentPosition.Level, currentPosition.Row, currentPosition.Col] == LadderDown)
                {
                    neighborPositions.Add(new Position(currentPosition.Level - 1, currentPosition.Row, currentPosition.Col));
                }

                neighborPositions.RemoveAll(pos => !IsValidPosition(pos, labyrinth));
            }

            return neighborPositions;
        }

        private static bool IsValidPosition(Position pos, char[, ,] labyrinth)
        {
            int levelsCount = labyrinth.GetLength(0),
                rowsCount = labyrinth.GetLength(1),
                colsCount = labyrinth.GetLength(2);

            if (IsInLabyrinth(pos, levelsCount, rowsCount, colsCount))
            {
                if (labyrinth[pos.Level, pos.Row, pos.Col] != Impassable)
                {
                    return true;
                }
            }
            else if (IsEscapePosition(pos, levelsCount, rowsCount, colsCount))
            {
                return true;
            }

            return false;
        }

        private static bool IsInLabyrinth(Position currentPosition, int levelsCount, int rowsCount, int colsCount)
        {
            if (currentPosition.Level >= 0 && currentPosition.Level < levelsCount &&
                currentPosition.Row >= 0 && currentPosition.Row < rowsCount &&
                currentPosition.Col >= 0 && currentPosition.Col < colsCount)
            {
                return true;
            }

            return false;
        }

        private static char[, ,] InitializeLabyrinthFromInput()
        {
            string[] levelsRowsColsStrings = Console.ReadLine().Split(' ');

            int levelsCount, rowsCount, colsCount;

            levelsCount = int.Parse(levelsRowsColsStrings[0]);
            rowsCount = int.Parse(levelsRowsColsStrings[1]);
            colsCount = int.Parse(levelsRowsColsStrings[2]);

            char[, ,] labyrinth = new char[levelsCount, rowsCount, colsCount];

            for (int level = 0; level < levelsCount; level++)
            {
                for (int row = 0; row < rowsCount; row++)
                {
                    string rowString = Console.ReadLine();
                    for (int col = 0; col < colsCount; col++)
                    {
                        labyrinth[level, row, col] = rowString[col];
                    }
                }
            }

            return labyrinth;
        }
    }
}