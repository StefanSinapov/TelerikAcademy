using System;
using System.Text;
class ForestRoad
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());

		char dot = '.';
		char star = '*';

		StringBuilder path = new StringBuilder();

		for (int i = 0; i < n; i++)
		{
			path.Append(new string(dot, i));
			path.Append(star);
			path.AppendLine(new string(dot, n - i - 1));
		}

		for (int i = 0; i < n - 1; i++)
		{
			path.Append(new string(dot, n - i - 4 / 2));
			path.Append(star);
			path.AppendLine(new string(dot, i + 1));
		}

		Console.WriteLine(path.ToString());
	}
}

