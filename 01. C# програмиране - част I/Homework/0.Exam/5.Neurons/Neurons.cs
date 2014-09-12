using System;
class Neurons
{
	static void Main()
	{
		string strNumber=Console.ReadLine();;
		while(strNumber!="-1")
		{
			char[] currentBinaryDigits = Convert.ToString(uint.Parse(strNumber), 2).ToCharArray();//PadLeft(32, '0').ToCharArray();
			//Console.WriteLine(currentBinaryDigits);
			
			bool startSpace = false;
			bool foundOne = false;
			bool endOfSpace = false;
			int lenghtOfSpace = 0;
			int lastOne = 0;
			for (int i = 0; i < currentBinaryDigits.Length; i++)
			{
				if (startSpace && lenghtOfSpace > 0 && currentBinaryDigits[i] == '1')
				{
					endOfSpace = true;
					break;
				}
				else if(currentBinaryDigits[i]=='1')
				{
					lastOne = i;
					foundOne = true;
				}
				else if(foundOne && currentBinaryDigits[i]=='0')
				{
					lenghtOfSpace++;
					startSpace = true;
					//foundOne = false;
				}
				
			}
			//make it zeroes
			for (int i = 0; i < currentBinaryDigits.Length; i++)
			{
				currentBinaryDigits[i] = '0';
			}

			//exchange
			if (endOfSpace)
			{
				for (int i = lastOne + 1; i < lastOne + 1 + lenghtOfSpace; i++)
				{
					currentBinaryDigits[i] = '1';
				}
			}

			//Console.WriteLine(currentBinaryDigits);
			//return the value
			uint result = Convert.ToUInt32(new string(currentBinaryDigits), 2);
			Console.WriteLine(result);

			//read the next element
			strNumber = Console.ReadLine();
		}
	}
}

//class ReplaceStartEnd
//{
//	static string ReplaceEnd(string input, char oldChar, char newChar)
//	{
//		char[] splitted = input.ToCharArray();

//		for (int ct = splitted.Length - 1; ct >= 0; ct--)
//		{
//			if (splitted[ct] == oldChar)
//			{
//				splitted[ct] = newChar;
//			}
//			else
//			{
//				break;
//			}
//		}

//		return new String(splitted);
//	}

//	static string ReplaceStart(string input, char oldChar, char newChar)
//	{
//		char[] splitted = input.ToCharArray();

//		for (int ct = 0; ct < splitted.Length; ct++)
//		{
//			if (splitted[ct] == oldChar)
//			{
//				splitted[ct] = newChar;
//			}
//			else
//			{
//				break;
//			}
//		}

//		return new String(splitted);
//	}

//	static void Main()
//	{
//		string text = "AAAAABBAACCAABB";

//		Console.WriteLine(text + "\n");
//		Console.WriteLine(ReplaceEnd(text, 'B', '*'));
//		Console.WriteLine(ReplaceStart(text, 'A', '-'));
//	}
//}