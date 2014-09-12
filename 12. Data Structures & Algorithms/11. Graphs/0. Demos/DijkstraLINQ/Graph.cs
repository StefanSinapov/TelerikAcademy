namespace DijkstraLINQ
{
    using System.Collections.Generic;

    public class Graph
    {
        public Graph()
        {
            this.Nodes = new Dictionary<string, Node>();
        }

        internal IDictionary<string, Node> Nodes { get; private set; }

        public void AddNode(string name)
        {
            var node = new Node(name);
            this.Nodes.Add(name, node);
        }

        public void AddConnection(string fromNode, string toNode, int distance, bool twoWay)
        {
            this.Nodes[fromNode].AddConnection(this.Nodes[toNode], distance, twoWay);
        }
    }
}
