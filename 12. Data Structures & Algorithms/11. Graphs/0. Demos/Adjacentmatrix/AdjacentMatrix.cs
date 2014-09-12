namespace AdjacentMatrix
{
    using System;

    public class AdjacentMatrix
    {
        public static void Main()
        {
            int nodes = int.Parse(Console.ReadLine());

            var graph = new int[nodes, nodes];

            // Read connections for each node
            for (int i = 0; i < nodes; i++)
            {
                string[] connections = Console.ReadLine().Split(' ');

                foreach (string connection in connections)
                {
                    graph[i, int.Parse(connection)] = 1;
                }
            }

            // Print the matrix
            for (int i = 0; i < nodes; i++)
            {
                for (int j = 0; j < nodes; j++)
                {
                    Console.Write(graph[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
