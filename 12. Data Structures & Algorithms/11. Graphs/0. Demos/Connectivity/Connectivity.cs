namespace Connectivity
{
    using System;
    using System.Collections.Generic;

   public class Connectivity
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
                            { 0, 1, 1, 0, 0, 0 },
                            { 0, 0, 1, 0, 0, 0 },
                            { 1, 1, 0, 0, 0, 0 },
                            { 0, 0, 0, 0, 0, 0 },
                            { 0, 0, 0, 0, 0, 1 },
                            { 0, 0, 0, 0, 1, 0 },
                        };

            int components = 0;
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (!visited[i])
                {
                    Bfs(i);
                    components++;
                }
            }

            Console.WriteLine("Connected components: " + components);

            if (components == 1)
            {
                Console.WriteLine("Graph is connected");
            }
            else
            {
                Console.WriteLine("Graph is not connected");
            }
        }
    }
}
