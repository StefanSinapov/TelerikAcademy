namespace MatrixTraversers
{
    using System;
    using System.Linq;

    /// <summary>
    /// Class that contain x and y coordinates of cell in two dimensional array
    /// </summary>
    internal class Cell
    {
        /// <summary>
        /// Create Cell with no initialized x and y
        /// </summary>
        public Cell()
        {
        }

        public Cell(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Value = 1;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Value { get; set; }
    }
}