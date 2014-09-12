namespace DijkstraLINQ
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DistanceCalculator
    {
        public IDictionary<string, double> CalculateDistances(Graph graph, string startingNode)
        {
            if (!graph.Nodes.Any(n => n.Key == startingNode))
            {
                throw new ArgumentException("Starting node must be in graph.");
            }

            this.InitializeGraph(graph, startingNode);
            this.ProcessGraph(graph, startingNode);
            return this.ExtractDistances(graph);
        }

        private void InitializeGraph(Graph graph, string startingNode)
        {
            foreach (Node node in graph.Nodes.Values)
            {
                node.DistanceFromStart = double.PositiveInfinity;
            }

            graph.Nodes[startingNode].DistanceFromStart = 0;
        }

        private void ProcessGraph(Graph graph, string startingNode)
        {
            bool finished = false;
            var queue = graph.Nodes.Values.ToList();
            while (!finished)
            {
                var nextNode =
                    queue.OrderBy(n => n.DistanceFromStart)
                        .FirstOrDefault(n => !double.IsPositiveInfinity(n.DistanceFromStart));
                if (nextNode != null)
                {
                    this.ProcessNode(nextNode, queue);
                    queue.Remove(nextNode);
                }
                else
                {
                    finished = true;
                }
            }
        }

        private void ProcessNode(Node node, List<Node> queue)
        {
            var connections = node.Connections.Where(c => queue.Contains(c.Target));
            foreach (var connection in connections)
            {
                double distance = node.DistanceFromStart + connection.Distance;
                if (distance < connection.Target.DistanceFromStart)
                {
                    connection.Target.DistanceFromStart = distance;
                }
            }
        }

        private IDictionary<string, double> ExtractDistances(Graph graph)
        {
            return graph.Nodes.ToDictionary(n => n.Key, n => n.Value.DistanceFromStart);
        }
    }
}
