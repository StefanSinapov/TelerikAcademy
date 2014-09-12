/*
 * Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height.
 * Define two new classes Triangle and Rectangle that implement the virtual method and 
 * return the surface of the figure (height*width for rectangle and height*width/2 for triangle). 
 * Define class Circle and suitable constructor so that at initialization height must be kept equal to 
 * width and implement the CalculateSurface() method. Write a program that tests the behavior of 
 * the CalculateSurface() method for different shapes (Circle, Rectangle, Triangle) stored in an array.
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Shapes
{
	class Program
	{
		static void Main()
		{

			//Rectangle
			Rectangle square = new Rectangle(2, 2);
			Console.WriteLine("Rectangle Surface: {0}", square.CalculateSurface());

			//Triangle
			Triangle triangle = new Triangle(4, 8);
			Console.WriteLine("Triangle surface: {0}", triangle.CalculateSurface());


			//Circle by given diameter
			Circle circle = new Circle(14);
			Console.WriteLine("Circle surface: {0}", circle.CalculateSurface());


			//in array 
			Shape[] shapes =
			{
				 new Rectangle(2, 2),
				 new Triangle(4,2.3),
				 new Circle(3.5),
				 new Triangle(11,7),
				 new Circle(4),
				 new Rectangle(4.5,3)
			};
			foreach (var shape in shapes)
			{
				Console.WriteLine("Shape type: {0} has surface {1}", shape.GetType(), shape.CalculateSurface());
			}
		}
	}
}
