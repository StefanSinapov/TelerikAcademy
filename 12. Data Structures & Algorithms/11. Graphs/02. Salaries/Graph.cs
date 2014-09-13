namespace _02.Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Graph<T>
    {
        internal IDictionary<T, Node<T>> Nodes { get; private set; }
        private readonly HashSet<Node<T>> visited;

        public Graph()
        {
            Nodes = new Dictionary<T, Node<T>>();
            visited = new HashSet<Node<T>>();
        }

        public void AddNode(T name)
        {
            var node = new Node<T>(name);
            if (Nodes.ContainsKey(name))
            {
                throw new ArgumentException(string.Format("Node with name {0} is existing in the graph.", name));
            }
            Nodes.Add(name, node);
        }

        public void AddConnection(T fromNode, T toNode, int distance, bool twoWay)
        {
            if (!Nodes.ContainsKey(fromNode))
            {
                this.AddNode(fromNode);
            }

            if (!Nodes.ContainsKey(toNode))
            {
                this.AddNode(toNode);
            }

            Nodes[fromNode].AddConnection(Nodes[toNode], distance, twoWay);
        }

        public List<Node<T>> FindShortestDistanceToAllNodes(T startNodeName)
        {
            if (!Nodes.ContainsKey(startNodeName))
            {
                throw new ArgumentOutOfRangeException(string.Format("{0} is not containing in the graph.", startNodeName));
            }

            SetShortestDistances(Nodes[startNodeName]);
            var nodes = new List<Node<T>>();
            foreach (var item in Nodes)
            {
                if (!item.Key.Equals(startNodeName))
                {
                    nodes.Add(item.Value);
                }
            }
            return nodes;
        }

        private void SetShortestDistances(Node<T> startNode)
        {
            var queue = new PriorityQueue<Node<T>>();

            // set to all nodes DijkstraDistance to PositiveInfinity
            foreach (var node in Nodes)
            {
                if (!startNode.Name.Equals(node.Key))
                {
                    node.Value.DijkstraDistance = double.PositiveInfinity;
                    //queue.Enqueue(node.Value);
                }
            }

            startNode.DijkstraDistance = 0.0d;
            queue.Enqueue(startNode);

            while (queue.Count != 0)
            {
                Node<T> currentNode = queue.Dequeue();

                if (double.IsPositiveInfinity(currentNode.DijkstraDistance))
                {
                    break;
                }

                foreach (var neighbour in Nodes[currentNode.Name].Connections)
                {
                    double subDistance = currentNode.DijkstraDistance + neighbour.Distance;

                    if (subDistance < neighbour.Target.DijkstraDistance)
                    {
                        neighbour.Target.DijkstraDistance = subDistance;
                        queue.Enqueue(neighbour.Target);
                    }
                }

            }
        }

        public void SetAllDijkstraDistanceValue(double value)
        {
            foreach (var node in Nodes)
            {
                node.Value.DijkstraDistance = value;
            }
        }

        public double GetSumOfAllDijkstraDistance()
        {
            foreach (var item in Nodes)
            {
                if (!visited.Contains(item.Value))
                {
                    EmployDfs(item.Value);
                }
            }
            double sum = 0;
            foreach (var node in Nodes)
            {
                sum += node.Value.DijkstraDistance;
            }

            return sum;
        }
        public void EmployDfs(Node<T> node)
        {
            visited.Add(node);
            foreach (var item in node.Connections)
            {
                if (!visited.Contains(item.Target))
                {
                    EmployDfs(item.Target);
                }
                node.DijkstraDistance += item.Target.DijkstraDistance;
            }

            if (node.DijkstraDistance == 0)
            {
                node.DijkstraDistance++;
            }

        }


        public void EmployBfs(T nodeName)
        {
            var nodes = new Queue<Node<T>>();
            Node<T> node = Nodes[nodeName];
            nodes.Enqueue(node);
            while (nodes.Count != 0)
            {
                Node<T> currentNode = nodes.Dequeue();
                currentNode.DijkstraDistance++;

                foreach (var connection in Nodes[currentNode.Name].Connections)
                {
                    nodes.Enqueue(connection.Target);
                }
            }
        }


        public List<Edge<T>> PrimeMinimumSpanningTree(T startNodeName)
        {
            if (!Nodes.ContainsKey(startNodeName))
            {
                throw new ArgumentOutOfRangeException(string.Format("{0} is not containing in the graph.", startNodeName));
            }

            var mpdTree = new List<Edge<T>>();
            var queue = new PriorityQueue<Edge<T>>();
            Node<T> node = Nodes[startNodeName];
            foreach (var edge in node.Connections)
            {
                queue.Enqueue(edge);
            }

            visited.Add(node);

            while (queue.Count > 0)
            {
                Edge<T> edge = queue.Dequeue();

                if (!visited.Contains(edge.Target))
                {
                    node = edge.Target;
                    visited.Add(node); //we "visit" this node
                    mpdTree.Add(edge);
                    foreach (var item in node.Connections)
                    {
                        if (!mpdTree.Contains(item))
                        {
                            if (!visited.Contains(item.Target))
                            {
                                queue.Enqueue(item);
                            }
                        }
                    }
                }
            }
            visited.Clear();
            return mpdTree;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var node in this.Nodes)
            {
                result.Append("(" + node.Key + ") -> ");

                foreach (var conection in node.Value.Connections)
                {
                    result.Append("(" + conection.Target + ") with:" + conection.Distance + " ");
                }

                result.AppendLine();
            }

            return result.ToString();
        }
    }
}