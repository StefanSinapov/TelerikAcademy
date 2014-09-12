namespace CohesionAndCoupling
{
    using System;
    using CohesionAndCoupling.Utility;

    public class UtilsExamples
    {
        public static void Main()
        {
            // File utilities 
            Console.WriteLine(FileUtilites.GetFileExtension("example"));
            Console.WriteLine(FileUtilites.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtilites.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtilites.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtilites.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtilites.GetFileNameWithoutExtension("example.new.pdf"));

            // Distance  -- class point with static methods
            Point pointA = new Point(1, -2);
            Point pointB = new Point(3, 4);
            Point pointC = new Point(-6, 4);
            Console.WriteLine(
                "\nDistance in the 2D space = {0:f2}",
                GeometryUtilities.CalcDistance2D(pointA, pointB));
            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                GeometryUtilities.CalcDistance3D(pointA, pointB, pointC));

            // Parallelepiped
            RectangularParallelepiped paral = new RectangularParallelepiped(3, 4, 5);
            Console.WriteLine("\nVolume = {0:f2}", paral.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", paral.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", paral.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", paral.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", paral.CalcDiagonalYZ());
        }
    }
}
