using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZigZagNumbers.Naive
{
    class ZigZagNaive
    {
        static int n;
        static int k;
        static HashSet<string> sequences;
        static bool[] used;

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

            used = new bool[n];

            int[] sequence = new int[k];
            sequences = new HashSet<string>();

            GenerateSequence(sequence, 0);
            return sequences.Count;
        }

        static void GenerateSequence(int[] sequence, int index)
        {
            if (index == k)
            {
                if (IsZigZag(sequence))
                {
                    var joined = string.Join(",", sequence);
                    sequences.Add(joined);
                }
                return;
            }


            for (int i = 0; i < n; i++)
            {
                if (!used[i])
                {
                    sequence[index] = i;
                    used[i] = true;
                    GenerateSequence(sequence, index + 1);
                    used[i] = false;
                }
            }
        }

        static bool IsZigZag(int[] sequence)
        {
            if (sequence.Length == 1)
            {
                return true;
            }
            if (sequence.Length == 2)
            {
                return sequence[0] > sequence[1];
            }

            for (int i = 1; i < sequence.Length - 1; i++)
            {
                var whenEven = i % 2 == 0 &&
                     !(sequence[i - 1] < sequence[i] && sequence[i] > sequence[i + 1]);
                var whenOdd =
                   i % 2 == 1 &&
                     !(sequence[i - 1] > sequence[i] && sequence[i] < sequence[i + 1]);

                if (whenEven || whenOdd)
                {
                    return false;
                }
            }
            return true;
        }
    }
}