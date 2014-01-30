using System;
class FindTheThirdBit
{
	static void Main()
	{
		//Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0
		int number = int.Parse(Console.ReadLine());
		int mask = 1 << 3;
		int result = mask & number;
		Console.WriteLine(result>>3);
	}
}

