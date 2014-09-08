namespace _01.Priority_Queue
{
    using System;
    using System.Collections.Generic;

    public class BinaryHeap<T>
    {
        private T[] heap;
        private readonly Comparison<T> comparison;
        private int index;

        public BinaryHeap()
            : this(4, null)
        { }

        public BinaryHeap(int capacity)
            : this(capacity, null)
        {

        }

        public BinaryHeap(int capacity, Comparison<T> comparison)
        {
            this.index = 1;
            this.heap = new T[capacity];
            this.comparison = comparison ?? Comparer<T>.Default.Compare;
        }

        public int Count
        {
            get { return this.index - 1; }
        }

        public void Insert(T item)
        {
            if (this.index == this.heap.Length)
            {
                this.Resize();
            }
            this.heap[this.index] = item;
            OrderUp(this.index);
            this.index++;
        }

        public T Pop()
        {
            T item = this.heap[1];
            this.index--;
            this.heap[1] = this.heap[this.index];
            OrderDown(1);
            return item;
        }

        public T Peek()
        {
            return this.heap[1];
        }

        private void OrderUp(int childIndex)
        {
            if (childIndex > 1)
            {
                var parentIndex = (childIndex) / 2;
                if (comparison.Invoke(this.heap[childIndex], this.heap[parentIndex]) < 0)
                {
                    T slap = this.heap[parentIndex];
                    this.heap[parentIndex] = this.heap[childIndex];
                    this.heap[childIndex] = slap;
                    OrderUp(parentIndex);
                }
            }
        }

        private void OrderDown(int rootIndex)
        {
            int leftChildIndex = rootIndex * 2;
            int rightChildIndex = rootIndex * 2 + 1;
            int minChild;

            if (leftChildIndex > this.index)
            {
                return;
            }

            if (rightChildIndex > this.index)
            {
                minChild = leftChildIndex;
            }
            else if (this.comparison(this.heap[leftChildIndex],this.heap[rightChildIndex]) < 0)
            {
                minChild = leftChildIndex;
            }
            else
            {
                minChild = rightChildIndex;
            }

            if (this.comparison(this.heap[minChild], this.heap[rootIndex]) != 0)
            {
                T swapValue = this.heap[rootIndex];
                this.heap[rootIndex] = this.heap[minChild];
                this.heap[minChild] = swapValue;

                rootIndex = minChild;
                OrderDown(rootIndex);
            }
        }

        private void Resize()
        {
            var newArray = new T[this.heap.Length * 2];
            Array.Copy(this.heap, 0, newArray, 0, this.heap.Length);
            this.heap = newArray;
        }

        public override string ToString()
        {
            return string.Join(", ", this.heap);
        }
    }
}