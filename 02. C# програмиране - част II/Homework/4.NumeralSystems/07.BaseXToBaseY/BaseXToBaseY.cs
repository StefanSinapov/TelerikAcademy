/*
* 7. Write a program to convert from any numeral system of given base x
* to any other numeral system of base y (2 ≤ x, y ≤  16).
*/
using System;
using System.Text;
class BaseXToBaseY
{
	static double Pow(int number, int power)
	{
		if (power == 0)
		{
			return 1;
		}
		double pass = number;
		for (int ct = 1; ct < power; ct++)
		{
			pass *= number;
		}

		return pass;
	}
	static string Reverse(string text)
	{
		if (text == null) return null;

		char[] array = text.ToCharArray();
		Array.Reverse(array);
		return new String(array);
	}
	static int ConvertXBaseToDecimal(string xBaseNumber, int baseX)
	{
		int result = 0;
		//now make all lethers upper
		xBaseNumber = xBaseNumber.ToUpper();
		int lenght = xBaseNumber.Length;
		for (int i = 0; i < lenght; i++)
		{
			switch (xBaseNumber[i])
			{
				case 'A':
					result += 10 * (int)Pow(baseX, lenght - i - 1);
					continue;
				case 'B':
					result += 11 * (int)Pow(baseX, lenght - i - 1);
					continue;
				case 'C':
					result += 12 * (int)Pow(baseX, lenght - i - 1);
					continue;
				case 'D':
					result += 13 * (int)Pow(baseX, lenght - i - 1);
					continue;
				case 'E':
					result += 14 * (int)Pow(baseX, lenght - i - 1);
					continue;
				case 'F':
					result += 15 * (int)Pow(baseX, lenght - i - 1);
					continue;
				default:
					break;
			}
			result += int.Parse(xBaseNumber[i].ToString()) * (int)Pow(baseX, lenght - i - 1);
		}

		return result;
	}
	static string ConvertDecimalToBaseY(int decNumber, int baseY)
	{
		string yBaseNumber = string.Empty;
		do
		{
			if ((decNumber % baseY) < 10)
			{
				yBaseNumber += decNumber % baseY;
			}
			else
			{
				switch (decNumber % baseY)
				{
					case 10:
						yBaseNumber += "A";
						break;
					case 11:
						yBaseNumber += "B";
						break;
					case 12:
						yBaseNumber += "C";
						break;
					case 13:
						yBaseNumber += "D";
						break;
					case 14:
						yBaseNumber += "E";
						break;
					case 15:
						yBaseNumber += "F";
						break;
					default:
						break;
				}
			}
			decNumber /= baseY;
		} while (decNumber != 0);

		//now just reverse the string
		yBaseNumber = Reverse(yBaseNumber);
		return yBaseNumber;
	}

	static void Main()
	{
		//logic: first we need to convert number to decimal and then to Y Base system
		//I'm gonna use two methods: XBaseToDecimal and DecimalToYBase

		Console.WriteLine("I'm converter from x to y base numeral systems. (2 ≤ x, y ≤  16)");
		Console.Write("First X Base system: ");
		int baseX = int.Parse(Console.ReadLine());
		Console.Write("Second Y Base system: ");
		int baseY = int.Parse(Console.ReadLine());
		Console.WriteLine();
		Console.Write("Number in {0} Base system = ",baseX);
		string xBaseNumber = Console.ReadLine();

		//from x base to decimal
		int decimalNumber = ConvertXBaseToDecimal(xBaseNumber, baseX);
		
		//from decimal to y base
		string result = ConvertDecimalToBaseY(decimalNumber, baseY);
		
		Console.WriteLine("Number {0} in {1}base system in {2}base system = {3}",xBaseNumber,baseX,baseY,result);
	}
}
