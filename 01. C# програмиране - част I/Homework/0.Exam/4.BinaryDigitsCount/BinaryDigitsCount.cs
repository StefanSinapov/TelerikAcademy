using System;
class BinaryDigitsCount
{
	static void Main()
	{
		int b = int.Parse(Console.ReadLine());
		int n = int.Parse(Console.ReadLine());

		int[] counter=new int[n];
		for (int i = 0; i < n; i++)
		{
			long number = long.Parse(Console.ReadLine());
			for (int j = 0; j < Convert.ToString(number,2).Length; j++)
			{
				int bit = (int)((number >> j) & 1);
				if(bit==b)
				{
					counter[i]++;
				}
			}
			
		}

		for (int i = 0; i < n; i++)
		{
			Console.WriteLine(counter[i]);
		}

	}
}

