namespace GraphTraversal
{
    using System;
    using System.Collections.Generic;

    public class BfsTraversal
    {
        private static bool[] visited;
        private static int[,] graph;

        public static void Bfs(int node)
        {
            var nodes = new Queue<int>();
            nodes.Enqueue(node);
            visited[node] = true;
            while (nodes.Count != 0)
            {
                int currentNode = nodes.Dequeue();
                Console.WriteLine(currentNode);

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[currentNode, i] == 1 && !visited[i])
                    {
                        nodes.Enqueue(i);
                        visited[i] = true;
                    }
                }
            }
        }

        public static void Main()
        {
            const int Nodes = 6;

            visited = new bool[Nodes];

            graph = new[,]
                        {
                            { 0, 1, 0, 0, 1, 0 },
                            { 1, 0, 1, 0, 0, 1 },
                            { 0, 0, 0, 1, 0, 0 },
                            { 0, 1, 0, 0, 0, 1 },
                            { 1, 0, 0, 1, 0, 1 },
                            { 1, 0, 1, 0, 1, 0 }
                        };

            Bfs(1);
        }
    }
}
