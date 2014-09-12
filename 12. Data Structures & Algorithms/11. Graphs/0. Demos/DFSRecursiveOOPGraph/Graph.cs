namespace DFSRecursiveOOPGraph
{
    using System;
    using System.Collections.Generic;

    public class Graph
    {
        private readonly HashSet<int> visited;
        private readonly int[][] childNodes;

        public Graph(int[][] nodes)
        {
            this.childNodes = nodes;
            this.visited = new HashSet<int>();
        }

        public void DfsRecursive(int node)
        {
            if (!this.visited.Contains(node))
            {
                this.visited.Add(node);
                Console.WriteLine(node);

                for (int i = 0; i < this.childNodes[node].Length; i++)
                {
                    this.DfsRecursive(this.childNodes[node][i]);
                }
            }
        }
    }
}
