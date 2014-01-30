using System;
class AstrologicalDigits
{
	static void Main()
	{
		string strNumber = Console.ReadLine();
		int sum=0;
		do
		{
			sum = 0;
			for (int i = 0; i < strNumber.Length; i++)
			{
				if(strNumber[i]=='-' || strNumber[i]=='.')
				{
					sum = sum + 0;
					continue;
				}
				sum = sum + (int)Char.GetNumericValue(strNumber[i]);
			}
			strNumber = sum.ToString();
		} while (sum>9);
		Console.WriteLine(sum);
	}
}

