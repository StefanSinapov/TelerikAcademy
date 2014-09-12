using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.DancingBits
{
	class DancingBits
	{
		static void Main()
		{
			int k = int.Parse(Console.ReadLine());
			int n = int.Parse(Console.ReadLine());
			//int number=13;
			//Console.WriteLine(Convert.ToString(number,2).PadLeft(16,'0'));
			int number;


			StringBuilder buildNumber=new StringBuilder();
			for (int i = 0; i < n; i++)
			{
				number = int.Parse(Console.ReadLine());
				buildNumber.Append(Convert.ToString(number, 2));
			}

			string concNumber = buildNumber.ToString();
			int counterBits = 1;
			int endCounter = 0;
			for (int i = 0; i < concNumber.Length; i=i+counterBits)
			{
				counterBits = 1;
				for (int j = i; j < concNumber.Length-1; j++)
				{
					if (concNumber[j + 1] == concNumber[j])
					{
						counterBits++;
					}
					else
					{
						break;
					}
				}
				if(counterBits==k)
				{
					endCounter++;
				}
				
			}
			Console.WriteLine(endCounter);
		}
	}
}
