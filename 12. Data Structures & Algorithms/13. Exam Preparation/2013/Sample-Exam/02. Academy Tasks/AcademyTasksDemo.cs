namespace _02.Academy_Tasks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class AcademyTasksDemo
    {
        public static int variety;
        public static List<int> problems;
        public static int bestResult;
        public static int maxIndex;

        static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input2.txt"));
#endif

            var numbers = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            problems = new List<int>(numbers);
            variety = int.Parse(Console.ReadLine());

            bestResult = problems.Count;
            var currentMin = problems[0];
            var currentMax = problems[0];
            maxIndex = -1;
            for (int i = 0; i < problems.Count; i++)
            {
                currentMin = Math.Min(currentMin, problems[i]);
                currentMax = Math.Max(currentMax, problems[i]);

                if (currentMax - currentMin >= variety)
                {
                    maxIndex = i;
                    break;
                }
            }

            if (maxIndex == -1)
            {
                Console.WriteLine(problems.Count);
                return;
            }

            Solve(0, 1, problems[0], problems[0]);

            Console.WriteLine(bestResult);
        }


        public static void Solve(int currentIndex, int taskSolved, int currentMin, int currentMax)
        {
            if ((currentMax - currentMin) >= variety)
            {
                bestResult = Math.Min(bestResult, taskSolved);
                return;
            }

            if (currentIndex >= maxIndex)
            {
                return;
            }

            for (int i = 2; i >= 1; i--)
            {
                if (currentIndex + i < problems.Count)
                {
                    Solve(currentIndex + i, taskSolved + 1, 
                        Math.Min(currentMin, problems[currentIndex + i]),
                        Math.Max(currentMax, problems[currentIndex + i]));

                    if (bestResult != problems.Count)
                    {
                        return;
                    }
                }
            }
        }

    }
}
