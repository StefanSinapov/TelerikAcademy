using System;
class ExchangePositionOfGivenBits
{
	static void Main()
	{
		//Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.


		uint number = uint.Parse(Console.ReadLine());
		//разменям стойностите на 3 и 24 бит
		uint maskBit3 = (number >> 3) & 1;
		uint maskBit24 = (number >> 24) & 1;
		number = number & (~(1u << 24)) | (maskBit3 << 24);
		number = number & (~(1u << 3)) | (maskBit24 << 3);

		uint maskBit4 = (number >> 4) & 1;
		uint maskBit25 = (number >> 25) & 1;
		number = number & (~(1u << 25)) | (maskBit4 << 25);
		number = number & (~(1u << 4)) | (maskBit25 << 4);

		uint maskBit5 = (number >> 5) & 1;
		uint maskBit26 = (number >> 26) & 1;
		number = number & (~(1u << 26)) | (maskBit5 << 26);
		number = number & (~(1u << 5)) | (maskBit26 << 5);

		Console.WriteLine(number);		
	}
}
