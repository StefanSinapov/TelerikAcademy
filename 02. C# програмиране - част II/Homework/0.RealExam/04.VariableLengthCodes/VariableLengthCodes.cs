using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class VariableLengthCodes
{
	static int[] numbersInDec;
	static string[] numbersInBin;
	static StringBuilder result = new StringBuilder();
	static StringBuilder encodedText=new StringBuilder();
	static int lines;
	struct Element
	{
		public char symbol;
		public int number;
		public string code;

		public Element(char symbol, int number, string code)
		{
			this.symbol = symbol;
			this.number = number;
			this.code = code;
		}

	}
	static List<Element> codeTable = new List<Element>();

	static void Main()
	{
		ReadInput();

		//turn number from dec to bin
		ConvertToBins();

		//make entire string
		TakeStringOfBins();

		//take the code for each element ; DONE
		
		//run over text take count of 1's and add this element to result
		int count = 1;
		for (int i = 0; i < encodedText.Length; i++)
		{
			if(encodedText[i]=='1')
			{
				count++;
				if (i == encodedText.Length - 1)
				{
					SearchThisEl(count-1);
					
				}
			}
			if(encodedText[i]=='0')
			{
				//търси тази буква в листа (тази с толкова 1ци)
				
				SearchThisEl(count-1);

				//нулира
				count = 1;
			}
		}


		Console.WriteLine(result.ToString());
	}

	private static void SearchThisEl(int count)
	{
		foreach(var element in codeTable)
		{
			string currentCode=string.Empty;
			for (int i = 0; i < count; i++)
			{
				currentCode+="1";
			}
			if(element.code==currentCode)
			{
				result.Append(element.symbol);
			}
		}
	}


	static void CodeOfElement(ref Element el)
	{
		for (int i = 0; i < el.number; i++)
		{
			el.code += "1";
		}
	}

	private static void TakeStringOfBins()
	{
		//append them
		for (int i = 0; i < numbersInBin.Length; i++)
		{
			encodedText.Append(numbersInBin[i]);
		}

		//take out the zeroes
		for (int i = encodedText.Length-1; i >= 0; i--)
		{
			if(encodedText[i]=='1')
			{
				break;
			}
			else if (encodedText[i] == '0')
			{
				encodedText.Remove(i, 1);
			}
		}
	}

	private static void ConvertToBins()
	{
		numbersInBin = new string[numbersInDec.Length];
		for (int i = 0; i < numbersInDec.Length; i++)
		{
			numbersInBin[i] = Convert.ToString(numbersInDec[i], 2);
		}
	}

	private static void ReadInput()
	{
		//dec numbers
		string[] strNumber = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		numbersInDec = new int[strNumber.Length];
		for (int i = 0; i < strNumber.Length; i++)
		{
			numbersInDec[i] = int.Parse(strNumber[i]);
		}

		//L - number of lines 
		lines = int.Parse(Console.ReadLine());

		//elements
		for (int i = 0; i < lines; i++)
		{
			Element elem = new Element();
			elem.symbol = (char)Console.Read();
			elem.number = int.Parse(Console.ReadLine());
			CodeOfElement(ref elem);
			
			codeTable.Add(elem);
		}
	}
}

