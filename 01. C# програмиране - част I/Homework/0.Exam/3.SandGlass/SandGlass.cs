using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class SandGlass
{
	static void Main(string[] args)
	{
		int n = int.Parse(Console.ReadLine());
		char dots='.';
		char stars='*';

		StringBuilder str = new StringBuilder();
		for (int i = 0; i < n/2; i++)
		{
			str.Append(new string(dots,i));
			str.Append(new string(stars,n-(i*2)));
			str.AppendLine(new string(dots, i));
		}

		str.Append(new string(dots, (n / 2) ));
		str.Append(stars);
		str.AppendLine(new string(dots, (n / 2)));

		for (int i = 0; i < n/2; i++)
		{
			str.Append(new string(dots,(n/2)-i-1));
			str.Append(new string(stars,2*(i+1)+1)); 
			str.AppendLine(new string(dots, (n / 2) - i-1));
		}

		Console.WriteLine(str.ToString());

	}
}

