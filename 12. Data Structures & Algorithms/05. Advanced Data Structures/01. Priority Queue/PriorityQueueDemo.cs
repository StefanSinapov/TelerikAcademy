/*
 * 1. Implement a class PriorityQueue<T> based on the 
 * data structure "binary heap".
 */
namespace _01.Priority_Queue
{
    using System;

    class PriorityQueueDemo
    {
        static void Main()
        {
            //BinaryHeapTest();

            var queue = new PriorityQueue<int>();

            queue.Enqueue(15);
            queue.Enqueue(6);
            queue.Enqueue(31);
            queue.Enqueue(2);
            queue.Enqueue(89);

            var count = queue.Count;

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }

        private static void BinaryHeapTest()
        {
            var heap = new BinaryHeap<int>();

            heap.Insert(50);
            heap.Insert(2);
            heap.Insert(26);
            heap.Insert(16);
            heap.Insert(66);
            heap.Insert(24);
            Console.WriteLine(heap);

            heap.Pop();
            Console.WriteLine(heap);

            heap.Insert(20);
            Console.WriteLine(heap);

            heap.Pop();
            Console.WriteLine(heap + " count: " + heap.Count);

            heap.Insert(90);
            Console.WriteLine(heap);
        }
    }
}
