namespace SizeCodeRefactoring
{
    using System;

    public class SizeDemo
    {
        public static void Main(string[] args)
        {
            Size figure = new Size(30, 10);
            double angleToRotate = 90;
            Size rotatedFigure = Size.GetRotatedSize(figure, angleToRotate);
            Console.WriteLine(rotatedFigure.Width + " " + rotatedFigure.Height);
        }
    }
}
