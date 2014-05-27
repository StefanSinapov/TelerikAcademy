namespace SimplifyIfStatement
{
    using System;
    using System.Linq;

    public class SimplifyIfStatement
    {
        private const int MinX = 0;
        private const int MaxX = int.MaxValue / 2;

        private const int MinY = 0;
        private const int MaxY = int.MaxValue / 4;

        public static void Main()
        {
            //// You can find first example in Project "01. Class" -> class "CookingTest.cs"

            int x = 10;
            int y = 15;

            if (IsCellPassable(x, y) && !IsCellVisited(x, y))
            {
                VisitCell(x, y);
            }
        }

        private static void VisitCell(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static bool IsCellVisited(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static bool IsCellPassable(int x, int y)
        {
            bool isCellPassable = x >= MinX && x <= MaxX &&
                                  MaxY >= y && MinY <= y;

            return isCellPassable;
        }
    }
}
