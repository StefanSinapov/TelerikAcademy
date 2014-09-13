namespace _02.Salaries
{
    using System;
    using System.Linq;

    class Salaries
    {

        private static long[] salaries;

        static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

            var count = long.Parse(Console.ReadLine());
            salaries = new long[count];

            var graph = new Graph<int>();

            for (int i = 0; i < count; i++)
            {
                var inputLine = Console.ReadLine();

                if (!graph.Nodes.ContainsKey(i))
                {
                    graph.AddNode(i);
                }


                for (int j = 0; j < count; j++)
                {
                    if (inputLine[j] == 'Y')
                    {
                        if (!graph.Nodes.ContainsKey(j))
                        {
                            graph.AddNode(j);
                        }

                        graph.AddConnection(i, j, 1, false);
                    }
                }
            }


            foreach (var node in graph.Nodes)
            {
                SetSalaries(node.Value);
            }

            long result = 0;
            for (int i = 0; i < salaries.Length; i++)
            {
                result += salaries[i];
            }

            Console.WriteLine(result);

        }

        private static void SetSalaries(Node<int> node)
        {
            if (!node.Connections.Any())
            {
                salaries[node.Name] = 1;
                return;
            }

            if (salaries[node.Name] != 0)
            {
                return;
            }

            foreach (var connection in node.Connections)
            {
                if (salaries[connection.Target.Name] == 0)
                {
                    SetSalaries(connection.Target);
                }

                salaries[node.Name] += salaries[connection.Target.Name];
            }
        }
    }
}
