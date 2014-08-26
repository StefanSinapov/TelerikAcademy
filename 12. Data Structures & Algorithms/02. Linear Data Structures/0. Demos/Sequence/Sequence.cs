using System;
using System.Collections.Generic;

class QueueExample
{
    static void Main()
    {
        int n = 3;
        int p = 16;

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(n);

        Console.WriteLine("N = {0}", n);
        Console.WriteLine("P = {0}", p);
        Console.Write("S =");

        int index = 0;
        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            Console.Write(" {0}", current);
            index++;

            if (current == p)
            {
                Console.WriteLine();
                Console.WriteLine("Index = {0} (starting from 1)", index);
                return;
            }
            queue.Enqueue(current + 1);
            queue.Enqueue(2 * current);
        }
    }
}
