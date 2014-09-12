/*
 * 1.Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. 
 * Implement the ToString() to enable printing a 3D point.
 * 
 * 2.Add a private static read-only field to hold the start of the coordinate system - 
 * the point O = {0, 0, 0}. Add a static property to return the point O.
 * 
 * 3.Write a static class with a static method to calculate the distance between two points in the 3D space.
 * 
 * 4.Create a class Path to hold a sequence of points in the 3D space. 
 * Create a static class PathStorage with static methods to save and load paths from a text file. 
 * Use a file format of your choice.
 */
using System;
class Program
{
	static Point3D[] GenerateRandomPoints(int count)
	{
		Point3D[] points = new Point3D[count];
		Random randomGen = new Random();
		for (int i = 0; i < points.Length; i++)
		{
			int x = randomGen.Next(0, 10);
			int y = randomGen.Next(0, 10);
			int z = randomGen.Next(0, 10);
			points[i] = new Point3D(x, y, z);
		}
		return points;
	}
	static void Main()
	{
		//add some point
		Point3D firstPoint = new Point3D(3, 4, 5);

		//print point, center and distance
		Console.WriteLine(firstPoint);
		Console.WriteLine(Point3D.Center);
		Console.WriteLine(Distance.Calculate(firstPoint,Point3D.Center));

		//add some points to the path
		Path starPath = new Path();
		starPath.Add(firstPoint);

		//See method above
		starPath.Add(GenerateRandomPoints(3));

		//print the path
		Console.WriteLine("-------Path-------");
		Console.WriteLine(starPath);


		//now lets make other path with random points and SAVE it in file
		Path milkyWay = new Path();
		milkyWay.Add(GenerateRandomPoints(5));
		PathStorage.Save(milkyWay, "../../milkyWay.txt");

		//Load path and print it
		Path loadedPath = PathStorage.Load("../../milkyWay.txt");
		Console.WriteLine("-------Loaded Path-----------");
		Console.WriteLine(loadedPath);
	}
}

