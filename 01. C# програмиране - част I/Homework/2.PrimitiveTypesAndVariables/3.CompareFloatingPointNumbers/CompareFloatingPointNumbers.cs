using System;
class CompareFloatingPointNumbers
{
	static void Main()
	{
		//Write a program that safely compares floating-point numbers with precision of 0.000001. Examples:(5.3 ; 6.01)  false;  (5.00000001 ; 5.00000003)  true

		//First example
		float a = 5.3f;
		float b = 6.01f;
		Console.WriteLine("compare {0} and {1}",a,b);
		if (Math.Abs(a - b) < 0.000001)
		{
			Console.WriteLine("true\n");
		}
		else
		{
			Console.WriteLine("false\n");
		}
		

		//Second example
		a = 5.00000001f;
		b = 5.00000003f;
		//Console.WriteLine("compare {0} and {1}", (decimal)a, (decimal)b);
		Console.WriteLine("compare 5.00000001 to 5.00000003");
		if (Math.Abs(a - b) < 0.000001)
		{
			Console.WriteLine("true\n");
		}
		else
		{
			Console.WriteLine("false\n");
		}
	}
}	
	