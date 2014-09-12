namespace DijkstraWithoutQueue
{
    using System;
    using System.Collections.Generic;

    public class DijkstraWithoutQueue
    {
        private static readonly int[] Distance = new int[10];
        private static readonly int?[] Previous = new int?[10];
        private static readonly HashSet<int> SetOfNodes = new HashSet<int>();

        public static void Dijkstra(int[,] graph, int source)
        {
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                Distance[i] = int.MaxValue;
                Previous[i] = null;
                SetOfNodes.Add(i);
            }

            Distance[source] = 0;

            while (SetOfNodes.Count != 0)
            {
                int minNode = int.MaxValue;

                foreach (var node in SetOfNodes)
                {
                    if (minNode > Distance[node])
                    {
                        minNode = node;
                    }
                }

                SetOfNodes.Remove(minNode);

                if (minNode == int.MaxValue)
                {
                    break;
                }

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[minNode, i] > 0)
                    {
                        int potentialDistance = Distance[minNode] + graph[minNode, i];
                        if (potentialDistance < Distance[i])
                        {
                            Distance[i] = potentialDistance;
                            Previous[i] = minNode;
                        }
                    }
                }
            }
        }

        public static void Main()
        {
            var graph = new[,]
                               {
                                   { 0, 23, 0, 0, 0, 0, 0, 8, 0, 0 },
                                   { 23, 0, 0, 3, 0, 0, 34, 0, 0, 0 },
                                   { 0, 0, 0, 6, 0, 0, 0, 25, 0, 7 },
                                   { 0, 3, 6, 0, 0, 0, 0, 0, 0, 0 },
                                   { 0, 0, 0, 0, 0, 10, 0, 0, 0, 0 },
                                   { 0, 0, 0, 0, 10, 0, 0, 0, 0, 0 },
                                   { 0, 34, 0, 0, 0, 0, 0, 0, 0, 0 },
                                   { 8, 0, 25, 0, 0, 0, 0, 0, 0, 30 },
                                   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                   { 0, 0, 7, 0, 0, 0, 0, 30, 0, 0 }
                               };

            int source = 1;

            Dijkstra(graph, source - 1);

            for (int i = 0; i < Distance.Length; i++)
            {
                Console.Write("Distance from 1 to {0}: ", i + 1);
                if (Distance[i] == int.MaxValue)
                {
                    Console.WriteLine("No path.");
                }
                else
                {
                    Console.Write("Path: ");

                    int? indexer = i;
                    while (indexer != 0)
                    {
                        Console.Write(indexer + 1 + " ");
                        indexer = Previous[indexer.Value];
                    }

                    Console.Write("1 ");

                    Console.WriteLine("Distance: " + Distance[i]);
                }
            }
        }
    }
}
