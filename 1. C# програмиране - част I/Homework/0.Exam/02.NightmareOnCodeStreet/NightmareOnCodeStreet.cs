using System;
using System.Text;
class NightmareOnCodeStreet
{
	static void Main()
	{
		string number = Console.ReadLine();
		int sum = 0;
		int counter = 0;
		int temp=0;
		for (int i = 0; i < number.Length; i++)
		{
			if(i % 2 != 0)
			{
				bool isNumber=int.TryParse(number[i].ToString(),out temp);
				if (isNumber)
				{
					sum += temp;
					counter++;
				}
				
			}
		}

		Console.WriteLine("{0} {1}",counter,sum);
	}
}

