namespace _03.Friends_in_Need
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FriendsInNeedDemo
    {
        public static Graph<int> Graph = new Graph<int>();
        public static HashSet<int> AllHospitals;
        static void Main()
        {

#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

            var firstLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray();

            int N = firstLine[0];
            int M = firstLine[1];
            int H = firstLine[2];


            var allHospitalsArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            AllHospitals = new HashSet<int>(allHospitalsArray);

            foreach (var hospital in AllHospitals)
            {
                Graph.AddNode(hospital);
            }

            for (int i = 0; i < M; i++)
            {
                var inputNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int firstNode = inputNumbers[0];
                int secondNode = inputNumbers[1];
                int distance = inputNumbers[2];

                Graph.AddConnection(firstNode, secondNode, distance, true);
            }


            var bestResult = int.MaxValue;
            foreach (var hospital in AllHospitals)
            {
                Graph.FindShortestDistanceToAllNodes(hospital);

                var currentResult =
                    Graph.Nodes.Where(n => !AllHospitals.Contains(n.Key)).Sum(x => x.Value.DijkstraDistance);

                if (currentResult < bestResult)
                {
                    bestResult = (int)currentResult;
                }
            }

            Console.WriteLine(bestResult);
        }
    }
}
