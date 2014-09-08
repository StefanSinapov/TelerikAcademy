/*
 * 3. Write a program that finds a set of words 
 * (e.g. 1000 words) in a large text (e.g. 100 MB text file).
 * Print how many times each word occurs in the text.
    * Hint: you may find a C# trie in Internet.
 */

/*
 * Trie implementation is get from https://github.com/rmandvikar/csharp-trie
 */
namespace _03.Trie
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text.RegularExpressions;
    using rmandvikar.Trie;

    class TrieDemo
    {
        private static readonly Stopwatch Stopwatch = new Stopwatch();

        static void Main()
        {
            const string filePath = @"..\..\words.txt";

            var trie = TrieFactory.GetTrie();

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    var words = Regex.Matches(reader.ReadToEnd(), @"\b\w+\b");

                    
                    Stopwatch.Start();
                    foreach (var word in words)
                    {
                        trie.AddWord(word.ToString());
                    }
                    Stopwatch.Stop();
                    Console.WriteLine("{0} words added to trie for {1}", words.Count, Stopwatch.Elapsed);


                    var extracted = trie.GetWords();

                    foreach (var word in extracted)
                    {
                        Console.WriteLine("{0}: {1} occurrences", word, trie.WordCount(word));
                    }
                }
            }
            catch (FileNotFoundException fe)
            {
                Console.WriteLine(fe.Message);
            }
        }
    }
}
