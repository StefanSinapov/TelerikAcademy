namespace Dictionary
{
    using System;
    using System.Collections.Generic;

    public class DictionaryGraph
    {
        public static void Main()
        {
            var graph = new Dictionary<string, List<string>>();

            string line = Console.ReadLine();
            while (line != string.Empty)
            {
                string[] connection = line.Split(' ');

                string first = connection[0];
                string second = connection[1];

                if (!graph.ContainsKey(first))
                {
                    graph[first] = new List<string>();
                }

                graph[first].Add(second);

                // Loop?
                if (first != second)
                {
                    if (!graph.ContainsKey(second))
                    {
                        graph[second] = new List<string>();
                    }

                    graph[second].Add(first);
                }

                line = Console.ReadLine();
            }

            foreach (var node in graph)
            {
                Console.Write(node.Key + " -> ");

                foreach (string neighbors in node.Value)
                {
                    Console.Write(neighbors + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
