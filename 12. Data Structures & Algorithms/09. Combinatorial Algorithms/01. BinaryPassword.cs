using System;
using System.Linq;
using System.Numerics;

class BinaryPassword
{
	static void Main()
	{
		string input = Console.ReadLine();

		int counter = input.Count(ch => ch == '*');

		Console.WriteLine((BigInteger)Math.Pow(2, counter));
	}
}

