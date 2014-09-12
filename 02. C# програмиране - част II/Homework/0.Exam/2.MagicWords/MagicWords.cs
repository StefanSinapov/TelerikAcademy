using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class MagicWords
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		List<string> words = new List<string>();
		int bestLength=0;
		for (int i = 0; i < n; i++)
		{
			words.Add(Console.ReadLine());
			if (words[i].Length > bestLength) bestLength = words[i].Length;
		}

		Reorder(words, n);
		string result = Print(words, bestLength, n);
		Console.WriteLine(result);
	}

	static string Print(List<string> words,int bestLenght, int n)
	{
		StringBuilder result=new StringBuilder();
		for (int i = 0; i < bestLenght; i++)
		{
			for (int j = 0; j < n; j++)
			{
				string currentWord = words[j];
				if(i<currentWord.Length)
				{
					result.Append(currentWord[i]);
				}
			}
		}
		return result.ToString();
	}

	static void Reorder(List<string> words, int n)
	{
		//int index = 0;
		for (int i = 0; i < n; i++)
		{
			int nextIndex = words[i].Length % (n + 1);
			string currentWord = words[i];
			
			if (nextIndex >= i)
			{
				words.Insert(nextIndex, currentWord);
				words.RemoveAt(i);
			}
			else
			{
				words.RemoveAt(i);
				words.Insert(nextIndex, currentWord);

			}
		}
	}
}

