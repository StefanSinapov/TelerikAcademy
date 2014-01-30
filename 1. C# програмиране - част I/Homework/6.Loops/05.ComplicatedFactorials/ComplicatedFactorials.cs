/*
 * Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).
*/
namespace _05.ComplicatedFactorials
{
	using System;
	using System.Numerics;
	class ComplicatedFactorials
	{
		static void Main()
		{
			Console.WriteLine("Please enter numbers N and K (1<N<K) and i'll calculate N!*K! / (K-N)! ");
			Console.Write("N= ");
			double n = double.Parse(Console.ReadLine());
			Console.Write("K= ");
			double k = double.Parse(Console.ReadLine());
			if (n > 1 && k > n)
			{
				BigInteger nFactorial = 1;
				for (int i = 1; i <= n; i++)
				{
					nFactorial *= i;
				}

				BigInteger kFactorial = 1;
				for (int i = 1; i <= k; i++)
				{
					kFactorial *= i;
				}

				BigInteger nMinusKFactorial = 1;
				for (int i = 1; i <= (k-n); i++)
				{
					nMinusKFactorial *= i;
				}

				BigInteger result = nFactorial * (kFactorial / nMinusKFactorial);
				Console.WriteLine("({0}! * {1}!({0}-{1})! = {2}",n,k,result);

			}
			else
			{
				Console.WriteLine("please enter valide data (1<K<N)");
			}
		}
	}
}
