using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Text.RegularExpressions;

class BunnyFactory
{
	static List<int> bunnies = new List<int>();
	static int n = 0;
	static void ReadInput()
	{
		string input = Console.ReadLine();
		while (input != "END")
		{
			n++;
			bunnies.Add(int.Parse(input));
			input = Console.ReadLine();
		}
	}

	static BigInteger SumOfFirstCages(int currentI)
	{
		BigInteger sum = 0;
		for (int i = 0; i < currentI + 1; i++)
		{
			sum += (BigInteger)bunnies[i];
		}
		return sum;
	}

	//start of i+1 because this is next element
	static BigInteger SumOfNextCages(int start, BigInteger count)
	{
		BigInteger sum = 0;
		for (int i = start + 1; i <= start + count; i++)
		{
			sum += (BigInteger)bunnies[i];
		}
		return sum;
	}

	static BigInteger ProductOfNextCages(int start, BigInteger count)
	{
		BigInteger product = 1;
		for (int i = start + 1; i <= start + count; i++)
		{
			product *= (BigInteger)bunnies[i];
		}
		return product;
	}

	static string ValueOfUntouche(int startAndCount)
	{
		StringBuilder value = new StringBuilder();
		for (int i = startAndCount; i < bunnies.Count; i++)
		{
			value.Append(bunnies[i].ToString());
		}
		return value.ToString();
	}

	static StringBuilder RemoveZeroes(StringBuilder str)
	{
		for (int i = 0; i < str.Length; i++)
		{
			if(str[i]=='0' || str[i]=='1')
			{
				str.Remove(i, 1);
				i--;
			}
		}
		return str;
	}

	static void AppendBunnies(StringBuilder str)
	{
		for (int i = 0; i < str.Length; i++)
		{
			bunnies.Add(int.Parse(str[i].ToString()));
		}
	}

	static void Main()
	{
		ReadInput();

		StringBuilder result = new StringBuilder();

		for (int i = 0; i < n; i++)
		{
			BigInteger firstSum = SumOfFirstCages(i);

			//TODO: if firstSum>n-i
			if(firstSum>=bunnies.Count-i)
			{
				break;
			}

			//calculate next Sums
			BigInteger sumOfNext = SumOfNextCages(i, firstSum);
			BigInteger productOfNext = ProductOfNextCages(i, firstSum);

			//concatenate
			result.Append(sumOfNext.ToString());
			result.Append(productOfNext.ToString());


			//TODO: check for untouche cages (n-i-firstSum) actualy from i+1+firstsum to size of array
			result.Append(ValueOfUntouche(i + 1 + (int)firstSum));

			//exclude zeroes and onces
			result = RemoveZeroes(result);
			
			//change the rabits in cages with new ones
			bunnies.Clear();
			AppendBunnies(result);

			//clear the result
			result.Clear();
		}

		foreach(int rabit in bunnies)
		{
			Console.Write(rabit+" ");
		}
	}
}

