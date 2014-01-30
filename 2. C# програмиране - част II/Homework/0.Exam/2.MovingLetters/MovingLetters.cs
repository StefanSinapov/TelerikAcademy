using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MovingLetters
{
	static string ExtractOfLetters(StringBuilder strangePieceOfWords)
	{
		return "";
	}
	static string MoveLetters(StringBuilder strangePieceOfWords)
	{
		for (int i = 0; i < strangePieceOfWords.Length; i++)
		{
			char currentSymbol = strangePieceOfWords[i];
			int transition = char.ToLower(currentSymbol) - 'a' + 1;

			//strangePieceOfWords.Replace(,,)
			int nextPosition = (i + transition) % strangePieceOfWords.Length;
			strangePieceOfWords.Remove(i, 1);
			strangePieceOfWords.Insert(nextPosition, currentSymbol);
		}


		return strangePieceOfWords.ToString();
	}
	static void Main()
	{
		//премахва празните места
		string[] words=Console.ReadLine().Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);

		StringBuilder strangeCombinationOfLetters = new StringBuilder();

		int maxWordLenght = 0;
		for (int i = 0; i < words.Length; i++)
		{
			if(maxWordLenght<words[i].Length)
			{
				maxWordLenght = words[i].Length;
			}
		}

		for (int i = 0; i <maxWordLenght ; i++)
		{
			for (int j = 0; j < words.Length; j++)
			{
				string currentWord = words[j];

				if(i<currentWord.Length)
				{
					int lastLetter = currentWord.Length - 1 - i;
					strangeCombinationOfLetters.Append(currentWord[lastLetter]);
				}
			}
		}

		Console.WriteLine(MoveLetters(strangeCombinationOfLetters).ToString());
	}
}

