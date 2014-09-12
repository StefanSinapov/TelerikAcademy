namespace GraphLibrary
{
	using System;
	using System.Collections.Generic;
	using System.Text;

    public class Graph<T>
    {
        internal IDictionary<T, Node<T>> Nodes { get; private set; }
        private HashSet<Node<T>> visited;

        public Graph()
        {
            Nodes = new Dictionary<T, Node<T>>();
            visited = new HashSet<Node<T>>();
        }

        public void AddNode(T name)
        {
            var node = new Node<T>(name);
            if(Nodes.ContainsKey(name))
            {
                throw new ArgumentException(string.Format("Node with name {0} is existing in the graph.", name));
            }
            Nodes.Add(name, node);
        }

        public void AddConnection(T fromNode, T toNode, int distance, bool twoWay)
        {
            if(!Nodes.ContainsKey(fromNode))
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
            List<Node<T>> nodes = new List<Node<T>>();
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
            PriorityQueue<Node<T>> queue = new PriorityQueue<Node<T>>();

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

                if (currentNode.DijkstraDistance == double.PositiveInfinity)
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

        public void setAllDijkstraDistanceValue(double value)
        {
            foreach (var node in Nodes)
            {
                node.Value.DijkstraDistance = value;
            }
        }

        public double getSumOfAllDijkstraDistance()
        {
            foreach (var item in Nodes)
            {
                if(!visited.Contains(item.Value))
                {
                    employDFS(item.Value);
                }
            }
            double sum = 0;
            foreach (var node in Nodes)
            {
                sum += node.Value.DijkstraDistance;
            }

            return sum;
        }
        public void employDFS(Node<T> node)
        {
            visited.Add(node);
            foreach (var item in node.Connections)
            {
                if (!visited.Contains(item.Target))
                {
                    employDFS(item.Target);
                }
                    node.DijkstraDistance += item.Target.DijkstraDistance;
            }

            if(node.DijkstraDistance == 0)
            {
                node.DijkstraDistance++;
            }
            
        }


        public void employBFS(T nodeName)
        {
            Queue<Node<T>> nodes = new Queue<Node<T>>();
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

            List<Edge<T>> mpdTree = new List<Edge<T>>();
            PriorityQueue<Edge<T>> queue = new PriorityQueue<Edge<T>>();
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
            StringBuilder result = new StringBuilder();

            foreach (var node in this.Nodes)
            {
                result.Append(node.Key + " -> ");

                foreach (var conection in node.Value.Connections)
                {
                    result.Append(conection.Target + "-" + conection.Distance + " ");
                }

                result.AppendLine();
            }

            return result.ToString();
        }
    }
}