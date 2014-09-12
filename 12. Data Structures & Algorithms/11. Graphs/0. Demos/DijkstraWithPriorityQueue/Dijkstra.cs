namespace DijkstraWithPriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class Dijkstra
    {
        public static void DijkstraAlgorithm(Dictionary<Node, List<Connection>> graph, Node source)
        {
            var queue = new PriorityQueue<Node>();

            foreach (var node in graph)
            {
                node.Key.DijkstraDistance = double.PositiveInfinity;
            }

            source.DijkstraDistance = 0.0d;
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();

                if (double.IsPositiveInfinity(currentNode.DijkstraDistance))
                {
                    break;
                }

                foreach (var neighbor in graph[currentNode])
                {
                    var potDistance = currentNode.DijkstraDistance + neighbor.Distance;
                    if (potDistance < neighbor.Node.DijkstraDistance)
                    {
                        neighbor.Node.DijkstraDistance = potDistance;
                        queue.Enqueue(neighbor.Node);
                    }
                }
            }
        }

        public static void Main()
        {
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node4 = new Node(4);
            var node5 = new Node(5);
            var node6 = new Node(6);
            var node7 = new Node(7);
            var node8 = new Node(8);
            var node9 = new Node(9);
            var node10 = new Node(10);

            var nodes = new List<Node> { node1, node2, node3, node4, node5, node6, node7, node8, node9, node10 };

            var graph = new Dictionary<Node, List<Connection>>
            {
                { node1, new List<Connection> { new Connection(node2, 23), new Connection(node8, 8) } },
                { node2, new List<Connection> { new Connection(node1, 23), new Connection(node4, 3), new Connection(node7, 34) } },
                { node3, new List<Connection> { new Connection(node4, 6), new Connection(node8, 25), new Connection(node10, 7) } },
                { node4, new List<Connection> { new Connection(node2, 3), new Connection(node3, 6) } },
                { node5, new List<Connection> { new Connection(node6, 10) } },
                { node6, new List<Connection> { new Connection(node5, 10) } },
                { node7, new List<Connection> { new Connection(node2, 34) } },
                { node8, new List<Connection> { new Connection(node1, 8), new Connection(node3, 25), new Connection(node10, 30) } },
                { node9, new List<Connection>() },
                { node10, new List<Connection> { new Connection(node3, 7), new Connection(node8, 30) } },
            };

            Node source = node1;

            DijkstraAlgorithm(graph, source);

            for (int i = 0; i < nodes.Count; i++)
            {
                Console.Write("Distance from {0} to {1} ", source.Id, i);
                Console.WriteLine(nodes[i].DijkstraDistance);
            }
        }
    }
}
