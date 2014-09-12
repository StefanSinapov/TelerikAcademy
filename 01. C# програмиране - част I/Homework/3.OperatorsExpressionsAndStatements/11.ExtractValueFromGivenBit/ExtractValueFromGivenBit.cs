using System;
class ExtractValueFromGivenBit
{
	static void Main()
	{
		int number = int.Parse(Console.ReadLine());
		int positions = int.Parse(Console.ReadLine());
		int mask = 1 << positions;
		int numberAndMask = number & mask;
		int result = numberAndMask >> positions;
		Console.WriteLine(result);
	}
}
//Write an expression that extracts from a given integer i the value of a given bit number b. 
//Example: i=5; b=2  value=1.

