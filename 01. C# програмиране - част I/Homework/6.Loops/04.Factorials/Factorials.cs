/*
 * Write a program that calculates N!/K! for given N and K (1<K<N).
*/
namespace _04.Factorials
{
	using System;
	using System.Numerics;
	class Factorials
	{
		static void Main()
		{
			Console.WriteLine("Please enter numbers N and K (1<K<N) and i'll calculate N!/K!");
			Console.Write("N= ");
			double n = double.Parse(Console.ReadLine());
			Console.Write("K= ");
			double k = double.Parse(Console.ReadLine());
			if (k > 1 && n > k)
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

				BigInteger result = nFactorial / kFactorial;
				Console.WriteLine("{0}!/{1}! = {2}", n, k, result);
			}
			else
			{
				Console.WriteLine("please enter valide data");
			}
		}
	}
}
