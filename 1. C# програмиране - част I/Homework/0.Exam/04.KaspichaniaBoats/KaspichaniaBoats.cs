using System;
using System.Text;
class KaspichaniaBoats
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		char stars='*';
		char dots='.';
		StringBuilder str = new StringBuilder();

		//head
		str.Append(new string(dots, n));
		str.Append(stars);
		str.AppendLine(new string(dots, n));

		//
		for (int i = 1; i < n; i++)
		{
			str.Append(new string(dots, n - i));
			//stars
			str.Append(stars);
			str.Append(new string(dots, i-1));
			str.Append(stars);
			str.Append(new string(dots, i-1));
			//stars
			str.Append(stars);
			str.AppendLine(new string(dots, n - i));
		}

		//width of the boat
		str.AppendLine(new string(stars, 2 * n + 1));

		//
		for (int i = 1; i <= n/2; i++)
		{
			str.Append(new string(dots, i));
			str.Append(stars);
			str.Append(new string(dots, n - i-1));
			str.Append(stars);
			str.Append(new string(dots, n - i-1));
			str.Append(stars);
			str.AppendLine(new string(dots, i));
		}


		//bottom
		str.Append(new string(dots, (n / 2) + 1));
		str.Append(new string(stars, n));
		str.AppendLine(new string(dots, (n / 2) + 1));


		Console.WriteLine(str.ToString());
	}
}

