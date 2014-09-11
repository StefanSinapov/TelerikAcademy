using System;

namespace ZigZagNumbers
{
    class ZigZagNumbersCounter
    {
        static int n;
        static int k;
        static bool[] used;
        static int seqCount;

        static void Main()
        {
            string consoleLine = Console.ReadLine();

            var args = consoleLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(args[0]);
            int k = int.Parse(args[1]);
            int result = Solve(n, k);
            Console.WriteLine(result);
        }

        static int Solve(int testN, int testK)
        {
            n = testN;
            k = testK;

            seqCount = 0;
            used = new bool[n];

            int[] sequence = new int[k];

            PutBigger(sequence, 0, -1);
            return seqCount;
        }

        static void PutBigger(int[] sequence, int index, int current)
        {
            if (index == k)
            {
                seqCount++;
                return;
            }

            if (current == n - 1)
            {
                return;
            }
            for (int i = current + 1; i < n; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    sequence[index] = i;
                    PutSmaller(sequence, index + 1, i);
                    used[i] = false;
                }
            }
        }

        static void PutSmaller(int[] sequence, int index, int current)
        {
            if (index == k)
            {
                seqCount++;
                return;
            }
            if (current == 0)
            {
                return;
            }
            for (int i = current - 1; i >= 0; i--)
            {
                if (!used[i])
                {
                    used[i] = true;
                    sequence[index] = i;
                    PutBigger(sequence, index + 1, i);
                    used[i] = false;
                }
            }
        }
    }
}