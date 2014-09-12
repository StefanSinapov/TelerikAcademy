using System;
class PrintEntireASCII
{
	static void Main()
	{
		char c;
		for (int i = 0; i < 128; i++)
		{
			c = (char)i;
			Console.Write(c+" ");
		}
	}
}

