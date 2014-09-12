namespace _4.FireInTheMatrix
{
	using System;
	using System.Text;
	using System.Collections.Generic;
	class Fire
	{
		static void Main()
		{
			char fire='#';
			char torchTop='-';
			char torchLeft='\\';
			char torchRight='/';
			char blank='.';

			int n=int.Parse(Console.ReadLine());
			
			int halfN = n/2;
			StringBuilder result = new StringBuilder();

			for (int i = 0; i < halfN; i++)
			{
				result.Append(new string(blank, halfN - (i + 1)));
				result.Append(new string(fire, 1));
				result.Append(new string(blank,i*2));
				result.Append(new string(fire, 1));
				result.AppendLine(new string(blank, halfN - i - 1));
				
			}
			for (int i = 0; i < halfN/2; i++)
			{
				result.Append(new string(blank,i));
				result.Append(new string(fire, 1));
				result.Append(new string(blank, (halfN - i - 1)*2));
				result.Append(new string(fire, 1));
				result.AppendLine(new string(blank, i));
			}

			result.AppendLine(new string(torchTop, n));
			for (int i = 0; i < halfN; i++)
			{
				result.Append(new string(blank,i));
				result.Append(new string(torchLeft, halfN - i));
				result.Append(new string(torchRight, halfN - i));
				result.AppendLine(new string(blank, i));
			}


			Console.WriteLine(result.ToString());
		}
	}
}
