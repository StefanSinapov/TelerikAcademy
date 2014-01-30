using System;
class CheckForPrimeNumbers
{
	static void Main()
	{
		//Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.
		int number = int.Parse(Console.ReadLine());
		if(number>0 && number<=100)
		{
			//The Murderous Method ((n²)+17)/12 = x.5 (work for all over and including 5)
			if ( (((((double)(number * number) + 17) / 12) * 10) % 5 == 0) || number==2 || number==3)
			{
				Console.WriteLine("Prime");
			}
			else
			{
				Console.WriteLine("Not prime");
			}
		}
		else 
		{
			Console.WriteLine("invalid data, please try again");
		}
	}
}
