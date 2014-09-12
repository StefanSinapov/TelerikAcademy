using System;
using System.Text;
class BatGoikoTower
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		char dot='.';
		char lDash='/';
		char rDash='\\';
		char line='-';
		StringBuilder str = new StringBuilder();
		for (int i = 0; i < n; i++)
		{
			str.Append(new string(dot, n - i-1));
			str.Append(lDash);
			if (i==1 || i==3 || i==6 || i==10 || i==15 || i==21 || i==28 || i==36)
			{
				str.Append(new string(line, i * 2));
			}
			else
			{
				str.Append(new string(dot, i * 2));
			}
			str.Append(rDash);
			str.AppendLine(new string(dot, n - i-1));
		}
		

		Console.WriteLine(str.ToString());
	}
}

