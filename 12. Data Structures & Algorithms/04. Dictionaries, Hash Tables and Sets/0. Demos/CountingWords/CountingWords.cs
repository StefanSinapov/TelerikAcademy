using System;
using System.Collections.Generic;

class CountingWords
{
    static void Main()
    {
        string text = "Welcome to our C# course. In this " +
            "course you will learn how to write simple " +
            "programs in C# and how to use data structures";

        Console.WriteLine("Dictionary<TKey,TValue>");
        Console.WriteLine("-----------------------");
        IDictionary<string, int> wordsCount = new Dictionary<string, int>();
        CountWords(text, wordsCount);

        Console.WriteLine();
        Console.WriteLine("SortedDictionary<TKey,TValue>");
        Console.WriteLine("-----------------------------");
        IDictionary<string, int> sortedWordsCount =
            new SortedDictionary<string, int>();
        CountWords(text, sortedWordsCount);
    }

    private static void CountWords(string text, IDictionary<string, int> wordsCount)
    {
        string[] words = text.Split(new char[] { ' ', ',', '.' },
            StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in words)
        {
            int count = 1;
            if (wordsCount.ContainsKey(word))
            {
                count = wordsCount[word] + 1;
            }
            wordsCount[word] = count;
        }
        foreach (var pair in wordsCount)
        {
            Console.WriteLine("{0} --> {1}", pair.Key, pair.Value);
        }
    }
}
