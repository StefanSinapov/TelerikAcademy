namespace CohesionAndCoupling
{
    using System;
    using System.Linq;

    public class Point
    {
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public override string ToString()
        {
            string output = string.Format("{0}({1}, {2})", this.GetType().Name, this.X, this.Y);
            return base.ToString();
        }
    }
}
