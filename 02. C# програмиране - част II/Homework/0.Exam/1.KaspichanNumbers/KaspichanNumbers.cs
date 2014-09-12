using System;
using System.Collections.Generic;
class KaspichanNumbers
{
	static void Main(string[] args)
	{
		ulong number = ulong.Parse(Console.ReadLine());
		List<string> digits = new List<string>();

		//first 25 digits
		for (char i = 'A'; i <= 'Z'; i++)
		{
			digits.Add(i.ToString());
		}

		//rest
		for (char i = 'a'; i <= 'i'; i++)
		{
			for (char j = 'A'; j <= 'Z'; j++)
			{
				digits.Add(i.ToString() + j.ToString());
			}
		}

		//foreach (var item in digits)
		//{
		//	Console.WriteLine(item + " ");
		//}

		string result = "";
		do
		{

			result = digits[(int)(number % 256)] + result;
			number /= 256;
		} while (number != 0);

		Console.WriteLine(result);
	}
}

