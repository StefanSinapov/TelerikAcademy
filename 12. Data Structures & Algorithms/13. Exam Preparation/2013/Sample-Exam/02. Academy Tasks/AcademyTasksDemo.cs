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

        static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

            var numbers = Console.ReadLine().Split(new char[]{' ', ','}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            problems = new List<int>(numbers);
            variety = int.Parse(Console.ReadLine());

            bestResult = problems.Count;
            var currentMin = int.MaxValue;
            var currentMax = int.MinValue;
            for (int i = 0; i < problems.Count; i++)
            {
                if (problems[i] < currentMin)
                {
                    currentMin = problems[i];
                }
                if (problems[i] > currentMax)
                {
                    currentMax = problems[i];
                }
            }

            if ((currentMax - currentMin) < variety)
            {
                Console.WriteLine(bestResult);
                return;
            }

            //
        }


        public static void Solve(int index, int currentMin, int currentMax)
        {
            if ((currentMax - currentMin) >= variety)
            {
                
            }

            if (index >= problems.Count)
            {
                return;
            }

            for (int i = 1; i <= 2; i++)
            {
                
            }
        }

    }
}
