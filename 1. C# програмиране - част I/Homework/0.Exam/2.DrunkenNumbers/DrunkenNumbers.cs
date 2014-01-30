using System;
class DrunkenNumbers
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		int numberLenght;

		int mitkoSum = 0;
		int vladkoSum = 0;

		for (int i = 0; i < n; i++)
		{
			int bears = int.Parse(Console.ReadLine());
			numberLenght = (bears.ToString().Length);
			if (numberLenght%2==0)
			{
				int strMitko = (bears / (int)Math.Pow(10, numberLenght / 2));
				int strVladko = (bears % (int)Math.Pow(10, numberLenght / 2));
				for (int j = 0; j < numberLenght/2; j++)
				{
					mitkoSum = mitkoSum + (strMitko % 10);
					strMitko = strMitko / 10;
					vladkoSum = vladkoSum + (strVladko % 10);
					strVladko /= 10;
				}
				//Console.WriteLine(strMitko);
				//Console.WriteLine(strVladko);
			}
			else
			{
				int strMitko = (bears / (int)Math.Pow(10, (numberLenght / 2)));
				int strVladko = (bears % (int)Math.Pow(10, (numberLenght / 2) + 1));
				for (int j = 0; j < (numberLenght / 2)+1; j++)
				{
					mitkoSum = mitkoSum+ (strMitko%10);
					strMitko = strMitko / 10;
					vladkoSum=vladkoSum+(strVladko%10);
					strVladko /= 10;
				}
				//Console.WriteLine(strMitko);
				//Console.WriteLine(strVladko);
			}
			//Console.WriteLine(bears.ToString().Length);
		}
		if (mitkoSum > vladkoSum)
		{
			Console.WriteLine("M {0}", mitkoSum - vladkoSum);
		}
		else if (mitkoSum < vladkoSum)
		{
			Console.WriteLine("V {0}", vladkoSum - mitkoSum);
		}
		else if(mitkoSum==vladkoSum)
		{
			Console.WriteLine("No {0}",vladkoSum+mitkoSum);
		}
	}
}

