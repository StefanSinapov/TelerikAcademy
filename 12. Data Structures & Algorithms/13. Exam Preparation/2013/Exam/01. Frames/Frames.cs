namespace _01.Frames
{
    using System;
    using System.Collections.Generic;

    class Frames
    {
        private static SortedSet<string> allPermutations = new SortedSet<string>();

        static void Main()
        {/*
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif
*/
            var numberOfFrames = int.Parse(Console.ReadLine());
            var frames = new Frame[numberOfFrames];

            for (int i = 0; i < numberOfFrames; i++)
            {
                string[] tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var frame = new Frame
                {
                    X = int.Parse(tokens[0]),
                    Y = int.Parse(tokens[1])
                };

                frames[i] = frame;
            }

            GeneratePermutations(frames, 0);

            Console.WriteLine(allPermutations.Count);
            foreach (var permutation in allPermutations)
            {
                Console.WriteLine(permutation);
            }
        }

        static void GeneratePermutations(Frame[] arr, int k)
        {
            if (k >= arr.Length)
            {
                allPermutations.Add(string.Join(" | ", arr).Trim());
            }
            else
            {
                GeneratePermutations(arr, k + 1);
                SwapValues(ref arr[k]);
                GeneratePermutations(arr, k + 1);
                SwapValues(ref arr[k]);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    GeneratePermutations(arr, k + 1);
                    SwapValues(ref arr[k]);
                    GeneratePermutations(arr, k + 1);
                    SwapValues(ref arr[k]);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }

        static void SwapValues(ref Frame frame)
        {
            int oldFirst = frame.X;
            frame.X = frame.Y;
            frame.Y = oldFirst;
        }
    }

    public struct Frame
    {
        public int X { get; set; }

        public int Y { get; set; }

        public override string ToString()
        {
            return string.Format("({0}, {1})", X, Y);
        }
    }
}
