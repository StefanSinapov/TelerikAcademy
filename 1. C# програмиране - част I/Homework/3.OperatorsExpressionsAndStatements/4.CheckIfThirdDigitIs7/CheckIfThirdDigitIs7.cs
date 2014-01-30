using System;
class CheckIfThirdDigitIs7
{
	static void Main()
	{
		//Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732  true
		int number=int.Parse(Console.ReadLine());
		if ((number / 100) % 10 == 7)
		{
			Console.WriteLine(true);
		}
		else
		{
			Console.WriteLine(false);
		}
	}
}

