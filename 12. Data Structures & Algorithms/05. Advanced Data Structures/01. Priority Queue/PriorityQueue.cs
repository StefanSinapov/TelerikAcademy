namespace _01.Priority_Queue
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private BinaryHeap<T> heap;
        private const int DefaultSize = 4;

        public PriorityQueue()
            : this(DefaultSize)
        {

        }

        public PriorityQueue(int capacity)
        {
            this.heap = new BinaryHeap<T>(capacity);
        }

        public PriorityQueue(int capacity, Comparison<T> comparison)
        {
             this.heap = new BinaryHeap<T>(capacity, null);
        }

        public int Count
        {
            get { return this.heap.Count; }
        }

        public void Enqueue(T element)
        {
            this.heap.Insert(element);
        }
        public T Dequeue()
        {
            return this.heap.Pop();
        }


    }
}