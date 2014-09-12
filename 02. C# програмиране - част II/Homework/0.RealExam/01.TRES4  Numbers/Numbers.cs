using System;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
class Numbers
{
	static Dictionary<int, string> table = new Dictionary<int, string>(){
	{0,"LON+"},
	{1,"VK-"} ,
	{2,"*ACAD"},
	{3,"^MIM"},
	{4,"ERIK|"},
	{5,"SEY&"},
	{6,"EMY>>"},
	{7,"/TEL"},
	{8,"<<DON"},
	};

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
	static void Main()
	{

		//BigInteger input = BigInteger.Parse(Console.ReadLine());
		string input = Console.ReadLine();

		string inputIn9 = DecToBaseY(BigInteger.Parse(input), 9);

		if(BigInteger.Parse(input)==0)
		{
			Console.WriteLine(table[0]);
			return;
		}

		StringBuilder result = new StringBuilder();
		for (int i = 0; i < inputIn9.Length; i++)
		{
			//BigInteger 
			result.Append(table[int.Parse(char.GetNumericValue(inputIn9[i]).ToString())]);
		}

		Console.WriteLine(result.ToString());
	}


	//Fifth Methid <- Fourth Method
	static char GetChar(BigInteger remainder)
	{
		//When we work with Integer, we compare with Integer value (BUT NOT WITH SYMBOLS)
		//Symbols starts with (Remainder >= 10)
		if (remainder >= 10)
			return (char)('A' + remainder - 10);
		else
			return (char)('0' + remainder);
	}

	//Fourth Method
	static string DecToBaseY(BigInteger dec, int baseY)
	{
		string decToY = string.Empty;

		while (dec != 0)
		{
			decToY = (dec % baseY) + decToY; //Fouth Method -> Fifth Method
			dec = dec / baseY;
		}

		return decToY;
	}
}

