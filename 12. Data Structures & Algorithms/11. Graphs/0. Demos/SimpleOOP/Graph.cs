namespace DFSRecursiveOOPGraph
{
    using System.Collections.Generic;

    public class Graph
    {
        public Graph(List<int>[] nodes)
        {
            this.ChildNodes = nodes;
        }

        public List<int>[] ChildNodes { get; set; }
    }
}
