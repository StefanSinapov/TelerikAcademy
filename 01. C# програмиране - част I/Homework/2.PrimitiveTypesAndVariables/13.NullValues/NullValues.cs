using System;
using System.Text;
class NullValues
{
	static void Main()
	{
		Console.OutputEncoding = Encoding.Unicode;
		int? isNullInteger = null;
		double? isNullDouble = null;
		Console.WriteLine(isNullDouble);
		isNullInteger = isNullInteger + 1;
		Console.WriteLine(isNullInteger);
		Console.WriteLine(isNullDouble+1);
	}
}

