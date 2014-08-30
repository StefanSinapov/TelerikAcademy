/*
 * 9. We are given the following sequence:
	S1 = N;
	S2 = S1 + 1;
	S3 = 2*S1 + 1;
	S4 = S1 + 2;
	S5 = S2 + 1;
	S6 = 2*S2 + 1;
	S7 = S2 + 2;
	...
	Using the Queue<T> class write a program to print its first 50 members for given N.
	Example: N=2 ? 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...
 */
namespace _09.Find_First_50_Members_of_Sequence
{
    using System;
    using System.Collections.Generic;

    class FindFirstMembersOfSequence
    {
        static void Main()
        {
            Console.Write("N = ");
            int startingNumber = int.Parse(Console.ReadLine());

            var result = FindSquence(startingNumber, 13);

            Console.WriteLine("Sequence: {0}", string.Join(", ", result));

        }

        private static IEnumerable<int> FindSquence(int startingNumber, int numberOfMembers)
        {
            var result = new List<int>();
            var queue = new Queue<int>();

            queue.Enqueue(startingNumber);
            result.Add(startingNumber);

            for (var i = 0; i < numberOfMembers/3; i++)
            {
                var previousNumber = queue.Dequeue();
                for (var j = 0; j < 3; j++)
                {
                    var nextNumber = Operations[j](previousNumber);
                    queue.Enqueue(nextNumber);
                    result.Add(nextNumber);
                }
            }
            return result;
        }

        private static readonly Func<int, int>[] Operations =
        {
            x => x + 1,
            x => 2 * x + 1,
            x => x + 2
        };
    }
}
