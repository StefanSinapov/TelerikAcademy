namespace _04.Towns
{
    using System;
    using System.Collections.Generic;

    class TownsDemo
    {
        public static int bestResult = 0;
        public static int descBestResult = 0;
        public static Node[] allNodes;

        static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

            var N = int.Parse(Console.ReadLine());
            allNodes = new Node[N];


            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var population = decimal.Parse(input[0]);
                var nodeName = input[1];
                var node = new Node {Name = nodeName, Population = population};
                allNodes[i] = node;
            }

            for (int i = 0; i < allNodes.Length; i++)
            {
//                SolveInc(i, i + 1, 1);
//                SolveInc(i, i + 2, 1);

                SolveDesc(i, i + 1, 1);
                SolveDesc(i, i + 2, 1);
            }

//            Console.WriteLine(bestResult);
            Console.WriteLine(descBestResult);
        }

        public static void SolveInc(int prevIndex, int index, int currentBest)
        {
            if (index >= allNodes.Length)
            {
                if (currentBest > bestResult)
                {
                    bestResult = currentBest;
                }
                return;
            }

            if (allNodes[prevIndex].Population >= allNodes[index].Population)
            {
                //check
                if (currentBest > bestResult)
                {
                    bestResult = currentBest;
                }
                return;
            }

            currentBest++;

            SolveInc(index, index + 1, currentBest);
            SolveInc(index, index + 2, currentBest);
        }

        public static void SolveDesc(int prevIndex, int index, int currentBest)
        {
            if (index >= allNodes.Length)
            {
                if (currentBest > descBestResult)
                {
                    descBestResult = currentBest;
                }
                return;
            }

            if (allNodes[prevIndex].Population < allNodes[index].Population)
            {
                //check
                if (currentBest > descBestResult)
                {
                    descBestResult = currentBest;
                }
                return;
            }

            currentBest++;

            SolveDesc(index, index + 1, currentBest);
            SolveDesc(index, index + 2, currentBest);
        }
    }

    struct Node
    {
        public string Name { get; set; }
        public decimal Population { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
