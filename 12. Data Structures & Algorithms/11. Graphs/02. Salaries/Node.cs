namespace _02.Salaries
{
    using System;
    using System.Collections.Generic;

    public class Node<T> : IComparable
    {
        IList<Edge<T>> _connections;

        public T Name { get; private set; }
        public double DijkstraDistance { get; set; }
        public List<Node<T>> DijkstraPath { get; set; }

        internal IEnumerable<Edge<T>> Connections
        {
            get { return _connections; }
        }

        public Node(T name)
        {
            Name = name;
            _connections = new List<Edge<T>>();
        }

        internal void AddConnection(Node<T> targetNode, double distance, bool twoWay)
        {
            if (targetNode == null)
            {
                throw new ArgumentNullException("targetNode");
            }

            if (targetNode == this)
            {
                throw new ArgumentException("Node may not connect to itself.");
            }

            if (distance < 0)
            {
                throw new ArgumentException("Distance must be positive.");
            }

            _connections.Add(new Edge<T>(this, targetNode, distance));
            if (twoWay)
            {
                targetNode.AddConnection(this, distance, false);
            }
        }

        public override string ToString()
        {
            return this.Name.ToString();
        }

        public int CompareTo(object obj)
        {
            return this.DijkstraDistance.CompareTo((obj as Node<T>).DijkstraDistance);
        }
    }
}