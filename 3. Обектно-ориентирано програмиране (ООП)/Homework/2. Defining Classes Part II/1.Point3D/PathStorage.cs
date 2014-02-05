using System;
using System.IO;
public static class PathStorage
{
	public static void Save(Path points,string filePath)
	{
		File.WriteAllText(filePath, points.ToString());
	}

	public static Path Load(string filePath)
	{
		Path path = new Path();
		using ( StreamReader reader=new StreamReader(filePath))
		{
			while(!reader.EndOfStream)
			{
				string[] coords = reader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				int x = int.Parse(coords[0]);
				int y = int.Parse(coords[1]);
				int z = int.Parse(coords[2]);
				path.Add(new Point3D(x,y,z));
			}
		}

		return path;
	}
}

