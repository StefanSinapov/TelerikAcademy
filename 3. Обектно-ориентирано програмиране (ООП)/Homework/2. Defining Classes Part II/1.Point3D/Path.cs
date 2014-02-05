using System;
using System.Collections.Generic;
public class Path
{
	//Fiealds
	private readonly List<Point3D> points;

	//Constructors
	public Path()
	{
		points = new List<Point3D>();
	}
	public Path(params Point3D[] points)
	{
		this.Add(points);
	}

	//Properties
	public Point3D this[int index]
	{
		get { return this.points[index]; }
		set { this.points[index]=value; }
	}

	//Methods
	public Path Add(params Point3D[] points)
	{
		foreach (var point in points)
		{
			this.points.Add(point);
		}
		return this;
	}
	public Path Remove(Point3D point)
	{
		this.points.Remove(point);
		return this;
	}
	public Path Clear()
	{
		this.points.Clear();
		return this;
	}

	public override string ToString()
	{
		return string.Join("\n", this.points);
	}
}

