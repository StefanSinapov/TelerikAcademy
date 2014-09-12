namespace _01.Friends_of_Pesho
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FriendsOfPesho
    {
        static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int streetsCount = int.Parse(input[1]);

            var hospitals = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


            var graph = new Dictionary<Node, List<Connection>>();
            var allNodes = new Dictionary<int, Node>();

            for (int i = 0; i < streetsCount; i++)
            {
                var currentStreet = Console.ReadLine().Split(' ');
                int firstNode = int.Parse(currentStreet[0]);
                int secondNode = int.Parse(currentStreet[1]);
                int distance = int.Parse(currentStreet[2]);


                if (!allNodes.ContainsKey(firstNode))
                {
                    allNodes.Add(firstNode, new Node(firstNode));
                }

                if (!allNodes.ContainsKey(secondNode))
                {
                    allNodes.Add(secondNode, new Node(secondNode));
                }

                var firstNodeObj = allNodes[firstNode];
                var secondNodeObj = allNodes[secondNode];

                if (!graph.ContainsKey(firstNodeObj))
                {
                    graph.Add(firstNodeObj, new List<Connection>());
                }
                if (!graph.ContainsKey(secondNodeObj))
                {
                    graph.Add(secondNodeObj, new List<Connection>());
                }

                graph[firstNodeObj].Add(new Connection(secondNodeObj, distance));
                graph[secondNodeObj].Add(new Connection(firstNodeObj, distance));
            }


            MarkHospitalNodes(hospitals, allNodes);


            long result = long.MaxValue;

            foreach (var hospital in hospitals)
            {
                var hospitalId = int.Parse(hospital);

                if (allNodes[hospitalId].IsHospital)
                {
                    DijkstraAlgorithm(graph, allNodes[hospitalId]);

                    long currentResult = allNodes.Where(node => !node.Value.IsHospital).Sum(node => (long) node.Value.DijkstraDistance);

                    if (currentResult <= result)
                    {
                        result = currentResult;
                    }
                }
            }

            Console.WriteLine(result);
        }

        private static void MarkHospitalNodes(IEnumerable<string> hospitals, Dictionary<int, Node> allNodes)
        {
            foreach (var hospital in hospitals)
            {
                allNodes[int.Parse(hospital)].IsHospital = true;
            }
        }

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
    }
}
