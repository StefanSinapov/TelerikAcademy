namespace AdvancedOOP
{
    using System;
    using System.Collections.Generic;

    public class Node
    {
        private readonly IList<Edge> connections;

        public Node(string name)
        {
            this.Name = name;
            this.connections = new List<Edge>();
        }

        public string Name { get; private set; }

        public IEnumerable<Edge> Connections
        {
            get { return this.connections; }
        }

        public void AddConnection(Node targetNode, double distance, bool twoWay)
        {
            if (targetNode == null)
            {
                throw new ArgumentNullException("targetNode");
            }

            if (targetNode == this)
            {
                throw new ArgumentException("Node may not connect to itself.");
            }

            if (distance <= 0)
            {
                throw new ArgumentException("Distance must be positive.");
            }

            this.connections.Add(new Edge(targetNode, distance));
            if (twoWay)
            {
                targetNode.AddConnection(this, distance, false);
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}