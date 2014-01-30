using System;
class ExchangeValuesOfVariables
{
	static void Main()
	{
		byte a = 5;
		byte b = 10;
		Console.WriteLine("a={0} and b={1}\n",a,b);
		byte c = b;
		b = a;
		a = c;
		Console.WriteLine("after exchange\n a={0} and b={1}",a,b);
	}
}

