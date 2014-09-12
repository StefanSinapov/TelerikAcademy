namespace TSUsingSourceDFS
{
    using System;
    using System.Collections.Generic;

    public class Graph
    {
        private readonly int[,] edges;

        private readonly int count;

        public bool[] VisitedElements;

        public List<int> SortedElements = new List<int>();

        public Graph(int[,] e)
        {
            this.edges = e;
            this.count = e.GetLength(0);
            this.VisitedElements = new bool[this.count];
        }

        public void Dfs(int startIndex)
        {
            this.VisitedElements[startIndex] = true;

            for (int k = 0; k < this.count; k++)
            {
                if ((this.edges[startIndex, k] == 1) && (this.VisitedElements[k] == false))
                {
                    this.Dfs(k);
                }
            }

            this.SortedElements.Add(startIndex);
        }


        public void TestDfs()
        {
            for (int i = 0; i < this.count; i++)
            {
                if (this.VisitedElements[i] == false)
                {
                    this.Dfs(i);
                }
            }
        }

        public void ShowSort()
        {
            this.SortedElements.Reverse();
            foreach (int node in this.SortedElements)
            {
                Console.Write("{0} ", node);
            }
        }
    }
}
