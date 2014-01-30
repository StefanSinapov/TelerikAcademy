using System;
using System.Numerics;
class Secrets
{
	static void Main()
	{
		BigInteger number = BigInteger.Parse(Console.ReadLine());
		BigInteger secretNumber = 0;
		if (number < 0)
		{
			number *= (-1);
		}
		BigInteger buffer = number;
		for (int i = 1; i <= number.ToString().Length; i++)
		{
			BigInteger digit = (BigInteger)buffer % 10;
			if (i%2!=0)
			{
				secretNumber += (digit * i * i);
				
			}
			else
			{
				secretNumber += (digit * digit * i);
				
			}
			buffer /= 10;
		}
		Console.WriteLine(secretNumber);


		BigInteger R = (secretNumber % 10);
		if (R==0)
		{
			Console.WriteLine("{0} has no secret alpha-sequence", number);
		}
		else
		{
			int remainder = (int)secretNumber % 26;
			for (int i = 0; i < R; i++)
			{
				if (remainder >= 26)
				{
					remainder = remainder - 26;
				}
				Console.Write("{0}", Convert.ToChar(64 + remainder + 1));
				remainder++;

			}
			Console.WriteLine();
		}

		
	}
}

