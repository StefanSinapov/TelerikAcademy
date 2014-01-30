using System;
class BooleanIfCanDivided
{
	static void Main()
	{
		int a=int.Parse(Console.ReadLine());
		bool can = ((a % 5 == 0 && a % 7 == 0) ? true : false);
		Console.WriteLine(can);
		//Write a boolean expression that checks for given integer
		// if it can be divided (without remainder) by 7 and 5 in the same time
	}
}

