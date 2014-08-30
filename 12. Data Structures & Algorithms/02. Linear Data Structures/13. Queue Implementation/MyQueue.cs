namespace _13.Queue_Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _11.LinkedList_Implementation;


    public class MyQueue<T> : IQueue<T>, IEnumerable<T>
    {

        private readonly MyLinkedList<T> elements;
        private const string NoElementsInQueueExceptionText = "There is no elements in queue.";

        public MyQueue()
        {
            this.elements = new MyLinkedList<T>();
        }


        public int Count
        {
            get { return this.elements.Count; }
        }

        public void Enqueue(T value)
        {
            this.elements.AddLast(value);
        }

         public T Peek()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException(NoElementsInQueueExceptionText);
            }

            return this.elements.First.Value;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                
                throw new ArgumentException(NoElementsInQueueExceptionText);
            }

            T value = this.elements.First.Value;
            this.elements.RemoveFirst();

            return value;
        }


        public void Clear()
        {
            this.elements.Clear();
        }


        public IEnumerator<T> GetEnumerator()
        {
            return this.elements.Cast<object>().Select(element => (T) element).GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}