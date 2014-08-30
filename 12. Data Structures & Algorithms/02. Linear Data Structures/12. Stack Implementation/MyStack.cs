namespace _12.Stack_Implementation
{
    using System;
    using System.Collections.Generic;

    public class MyStack<T> : IStack<T>, IEnumerable<T>
    {

        private const int DefaultCapacity = 4;
        private const string NegativeCapacityExceptionText = "Capacity must be non-negative number.";
        private const string NullSeedExceptionText = "Seed collection cannot be null.";

        private T[] elements;

        public MyStack()
            : this(DefaultCapacity)
        {

        }

        public MyStack(int capacity)
        {
            Count = 0;
            if (capacity < 0)
            {

                throw new ArgumentOutOfRangeException(NegativeCapacityExceptionText);
            }

            this.elements = new T[Math.Max(DefaultCapacity, capacity)];
        }

        public MyStack(IEnumerable<T> collection)
            : this()
        {
            if (collection == null)
            {
                throw new NullReferenceException(NullSeedExceptionText);
            }

            foreach (var element in collection)
            {
                this.Push(element);
            }
        }

        public int Count { get; private set; }

        public void Push(T value)
        {
            this.ExpandCapacity();
            this.elements[this.Count++] = value;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("There is no elements in stack.");
            }

            var value = this.elements[this.Count - 1];
            this.elements[this.Count - 1] = default(T);
            this.Count--;

            return value;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("There is no elements in stack.");
            }

            return this.elements[this.Count - 1];
        }

        public void Clear()
        {
            Array.Clear(this.elements, 0, this.Count);
            this.Count = 0;
        }


        public T[] ToArray()
        {
            return this.elements;
        }

        public void TrimExcess()
        {
            int length = (int)(this.elements.Length * 0.9);

            if (this.Count < length)
            {
                T[] resizedArray = new T[this.Count];
                Array.Copy(this.elements, 0, resizedArray, 0, this.Count);
                this.elements = resizedArray;
            }
        }


        int IStack<T>.Count()
        {
            return this.Count;
        }

        private void ExpandCapacity()
        {
            if (this.Count == this.elements.Length)
            {
                T[] resizedArray = new T[this.elements.Length == 0 ? DefaultCapacity : 2 * this.elements.Length];
                Array.Copy(this.elements, 0, resizedArray, 0, this.Count);
                this.elements = resizedArray;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.elements[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}