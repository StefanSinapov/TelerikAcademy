using System;
class ExchangeBits
{
	static void Main()
	{
		//* Write a program that exchanges bits {p, p+1, …, p+k-1) 
		//with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.
		Console.Write("Number: ");
		uint number=uint.Parse(Console.ReadLine());
		Console.Write("From bit number =");
		int p = int.Parse(Console.ReadLine());
		Console.Write("Length = ");
		int k = int.Parse(Console.ReadLine());
		Console.Write("With bit number =");
		int q = int.Parse(Console.ReadLine());

		uint maskBitI;
		uint maskBitJ;
		int j = q;
		for(int i=p;i<=p+k-1;i++)
		{
			
			maskBitI = (number >> i) & 1;
			maskBitJ = (number >> j) & 1;
			number = number & (~(1u << j)) | (maskBitI << j);
			number = number & (~(1u << i)) | (maskBitJ << i);
			j++;
		}

		Console.WriteLine(number);
	}
}

