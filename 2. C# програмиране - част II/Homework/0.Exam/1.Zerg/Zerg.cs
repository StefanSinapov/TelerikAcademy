using System;
class Zerg
{
	static double Pow(int number, int power)
	{
		if (power == 0)
		{
			return 1;
		}
		double pass = number;
		for (int ct = 1; ct < power; ct++)
		{
			pass *= number;
		}

		return pass;
	}
	static int ReturnZergDigit(string currentDigit)
	{
		switch (currentDigit)
		{
			case "Rawr": return 0;
			case "Rrrr": return 1;
			case "Hsst": return 2;
			case "Ssst": return 3;
			case "Grrr": return 4;
			case "Rarr": return 5;
			case "Mrrr": return 6;
			case "Psst": return 7;
			case "Uaah": return 8;
			case "Uaha": return 9;
			case "Zzzz": return 10;
			case "Bauu": return 11;
			case "Djav": return 12;
			case "Myau": return 13;
			case "Gruh": return 14;
			default:
				return 0;
		}

	}
	static void Main()
	{
		string messege = Console.ReadLine();
		ulong result = 0;
		int index = messege.Length / 4;
		for (int i = 0; i < messege.Length; i += 4)
		{
			string currentDigit = messege.Substring(i, 4);

			result += (ulong)ReturnZergDigit(currentDigit) * (ulong)Pow(15, index-1);
			index--;
		}

		Console.WriteLine(result);
	}
}

