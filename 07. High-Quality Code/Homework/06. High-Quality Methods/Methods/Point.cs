namespace Methods
{
    using System;

    public class Point
    {
        private double x;
        private double y;

        public Point(double initialX, double initialY)
        {
            this.X = initialX;
            this.Y = initialY;
        }

        public double X
        {
            get
            {
                return this.x;
            }

            set
            {
                this.x = value;
            }
        }

        public double Y
        {
            get
            {
                return this.y;
            }

            set
            {
                this.y = value;
            }
        }

        public static double CalculateDistance(Point first, Point second)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException("Point cannot be null reference");
            }

            double newXCoord = (second.X - first.X) * (second.X - first.X);
            double newYCoord = (second.Y - first.Y) * (second.Y - first.Y);
            double result = Math.Sqrt(newXCoord + newXCoord);
            return result;
        }

        public static bool AreVerticle(Point first, Point second)
        {
            bool areVertical = first.X == second.X;
            return areVertical;
        }

        public static bool AreHorizontal(Point first, Point second)
        {
            bool areHorizontal = first.Y == second.Y;
            return areHorizontal;
        }

        public override string ToString()
        {
            string result = string.Format("({0}, {1})", this.X, this.Y);
            return result;
        }
    }
}
