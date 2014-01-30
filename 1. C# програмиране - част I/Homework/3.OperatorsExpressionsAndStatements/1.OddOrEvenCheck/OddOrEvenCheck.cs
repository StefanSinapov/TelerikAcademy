using System;
class OddOrEvenCheck
{
	static void Main()
	{
		int a = int.Parse(Console.ReadLine());

		//if(a%2==0)
		//{
		//	Console.WriteLine("Even");
		//}
		//else
		//{
		//	Console.WriteLine("Odd");
		//}

		string result=(a%2==0 ? "even":"odd" );
		Console.WriteLine(result);
	}
}

