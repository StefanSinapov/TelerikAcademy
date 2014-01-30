using System;
class MissCat
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		byte[] cats=new byte[n];
		for (int i = 0; i < n; i++)
		{
			cats[i]=byte.Parse(Console.ReadLine());
		}


		int counter = 0;
		int buffer=1;
		int winner = 0;

		Array.Sort(cats);
		Array.Reverse(cats);

		for (int i = 1; i < n; i++)
		{
			if(cats[i-1]==cats[i])
			{
				buffer++;
			}
			else
			{
				buffer = 1;
			}
			if(buffer>=counter)
			{
				counter = buffer;
				winner = cats[i];
			}
			
		}

		if(n==1)
		{
			winner = cats[0];
		}
		Console.WriteLine(winner);

	}
}

