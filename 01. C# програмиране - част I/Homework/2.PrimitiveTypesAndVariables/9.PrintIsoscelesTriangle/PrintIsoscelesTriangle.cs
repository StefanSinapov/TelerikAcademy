using System;
using System.Text;
class PrintIsoscelesTriangle
{
	static void Main()
	{
		//Write a program that prints an isosceles triangle of 9 copyright symbols ©.
		//Use Windows Character Map to find the Unicode code of the © symbol. 
		//Note: the © symbol may be displayed incorrectly.

		Console.OutputEncoding = Encoding.UTF8;
		char c = '\u00A9';
		string firstRow = "  " + c;
		string secondRow = " " + c + c + c;
		string thirdRow = "" + c + c + c + c + c;
		Console.WriteLine(firstRow);
		Console.WriteLine(secondRow);
		Console.WriteLine(thirdRow);

	}
}

