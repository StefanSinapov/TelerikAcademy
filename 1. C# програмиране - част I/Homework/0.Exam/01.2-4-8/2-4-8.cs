using System;
using System.Numerics;
class Program
{
	static void Main()
	{
		checked
		{
			BigInteger A = BigInteger.Parse(Console.ReadLine());
			BigInteger B = BigInteger.Parse(Console.ReadLine());
			BigInteger C = BigInteger.Parse(Console.ReadLine());

			BigInteger R = 0;
			switch ((int)B)
			{
				case 2: R = A % C;
					break;
				case 4: R = A + C;
					break;
				case 8: R = A * C;
					break;
			}


			if (R % 4 == 0)
			{
				Console.WriteLine(R / 4);
			}
			else
			{
				Console.WriteLine(R % 4);
			}
			Console.WriteLine(R);
		}
	}
}

