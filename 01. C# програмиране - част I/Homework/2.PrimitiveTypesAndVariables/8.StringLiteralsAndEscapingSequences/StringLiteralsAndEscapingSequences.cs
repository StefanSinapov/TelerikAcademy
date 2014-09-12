using System;
class StringLiteralsAndEscapingSequences
{
	static void Main()
	{

		string firstString=@"The ""use"" of quotations causes difficulties.";
		Console.WriteLine(firstString);
		string secondString = "The \"use\" of quotations causes difficulties.";
		Console.WriteLine(secondString);

	}
}
	
