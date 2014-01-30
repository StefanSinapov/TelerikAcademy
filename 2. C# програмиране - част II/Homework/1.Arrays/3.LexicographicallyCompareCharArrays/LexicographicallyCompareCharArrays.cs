/*
 * Write a program that compares two char arrays lexicographically (letter by letter).
*/
using System;
class LexicographicallyCompareCharArrays
{
	static void Main()
	{
	
		//read the lenght of char arrays
		Console.Write("Lenght of first char array: "); 
		char[] firstChArray = new char[int.Parse(Console.ReadLine())];
		Console.Write("Lenght of second char array: ");
		char[] secondChArray = new char[int.Parse(Console.ReadLine())];

		//reading tha char arrays
		Console.WriteLine("First Char Array:");
		for (int i = 0; i < firstChArray.Length; i++)
		{
			Console.Write("char[{0}]= ",i);
			firstChArray[i]=char.Parse(Console.ReadLine());
		}

		Console.WriteLine("Second Char Array:");
		for (int i = 0; i < secondChArray.Length; i++)
		{
			Console.Write("char[{0}]= ", i);
			secondChArray[i] = char.Parse(Console.ReadLine());
		}

		//comparing char arrays
		for (int i = 0; i < firstChArray.Length; i++)
		{
			if (firstChArray[i] > secondChArray[i])
			{
				Console.WriteLine("Second array is first");
				break;
			}
			else if (firstChArray[i] < secondChArray[i])
			{
				Console.WriteLine("First array is first");
				break;
			}
			else if(firstChArray.Length>secondChArray.Length)
			{
				if(i==secondChArray.Length-1)
				{
					Console.WriteLine("Second array is first");
				}
			}
			else if(firstChArray.Length<secondChArray.Length)
			{
				if(i==firstChArray.Length-1)
				{
					Console.WriteLine("First array is first");
				}
			}
		}


	}
}

