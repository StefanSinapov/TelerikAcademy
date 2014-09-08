/*
 * 3. Write a program that counts how many times each word 
 * from given text file words.txt appears in it. 
 * The character casing differences should be ignored. 
 * The result words should be ordered by their number of occurrences in the text.
 * 
	Example: {This is the TEXT. Text, text, text – THIS TEXT! Is this the text?}
	is -> 2
	the -> 2
	this -> 3
	text -> 6
 */
namespace _03.Words_Count
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class WordsCount
    {
        static void Main()
        {
            
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../text.txt"));
#endif
            string input = Console.ReadLine();
            var wordsDict = new Dictionary<string, int>();
            
            ProccessInput(wordsDict, input);
            PrintCount(wordsDict, input);
        }

        private static void PrintCount(Dictionary<string, int> wordsDict, string input)
        {
            var wordsSorted = wordsDict.Select(d => new
            {
                Word = d.Key,
                Count = d.Value
            }).OrderBy(d => d.Count);

            Console.WriteLine("Text: {0}", input);
            foreach (var pair in wordsSorted)
            {
                Console.WriteLine("{0} -> {1} times", pair.Word, pair.Count);
            }
        }

        private static void ProccessInput(Dictionary<string, int> wordsDict, string input)
        {
            input = input.ToLower();
            var word = new StringBuilder();
            foreach (char c in input)
            {
                if (c >= 'a' && c <= 'z')
                {
                    word.Append(c);
                }
                else if (word.Length > 0)
                {
                    string wordAsString = word.ToString();
                    if (!wordsDict.ContainsKey(wordAsString))
                    {
                        wordsDict.Add(wordAsString, 0);
                    }
                    wordsDict[wordAsString]++;
                    word.Clear();
                }
            }

            if (word.Length > 0)
            {
                string wordString = word.ToString();
                if (!wordsDict.ContainsKey(wordString))
                {
                    wordsDict.Add(wordString, 0);
                }
                wordsDict[wordString]++;
                word.Clear();
            }
        }
    }
}
