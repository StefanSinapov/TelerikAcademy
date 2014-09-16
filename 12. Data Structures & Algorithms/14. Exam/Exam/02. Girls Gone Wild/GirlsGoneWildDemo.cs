namespace _02.Girls_Gone_Wild
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class GirlsGoneWildDemo
    {
        private static int K;
        private static int N;
        private static string L;
        public static SortedSet<string> allCombinations = new SortedSet<string>();
        private static string[] combinations;
        private static string[] stringCombinations;


        static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

            K = int.Parse(Console.ReadLine());
            L = Console.ReadLine();
            N = int.Parse(Console.ReadLine());

            combinations = new string[N];
            stringCombinations = new string[N];

            Combinations(0, 0 ,0);
            //StringCombinations(0);
        }

        private static void Combinations(int startValue, int numberIndex, int strIndex)
        {
            if (numberIndex >= N && strIndex >= L.Length)
            {
                Print();
                return;
            }

            for (int i = startValue; i < K; i++)
            {
                combinations[numberIndex] = i.ToString() + L[strIndex];
                Combinations(i, numberIndex, strIndex + 1);
                Combinations(i + 1, numberIndex + 1, 0);
            }
        }

        private static void StringCombinations(int startValue, int currentLoop = 0)
        {
            if (currentLoop >= N)
            {
                PrintStrings();
                return;
            }

            for (int i = startValue; i < L.Length; i++)
            {
               
            }
        }

        private static void Print()
        {
            Console.WriteLine("({0})", string.Join(", ", combinations));
        }
        private static void PrintStrings()
        {
            Console.WriteLine("({0})", string.Join(", ", stringCombinations));
        }
    }
}
