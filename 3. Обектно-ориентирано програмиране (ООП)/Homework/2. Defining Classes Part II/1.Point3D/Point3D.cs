public struct Point3D
{
	// Fields + Properties
	public int X { get; set; }
	public int Y { get; set; }
	public int Z { get; set; }
	//static field
	private static readonly Point3D center = new Point3D(0, 0, 0);

	public Point3D(int x, int y, int z)
		: this()
	{
		this.X = x;
		this.Y = y;
		this.Z = z;
	}

	public static Point3D Center
	{
		get { return center; }
	}

	public override string ToString()
	{
		return string.Format("{0} {1} {2}", this.X, this.Y, this.Z);
	}
}
