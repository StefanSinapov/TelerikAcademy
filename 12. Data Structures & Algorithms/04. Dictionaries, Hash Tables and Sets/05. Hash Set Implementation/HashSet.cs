namespace _05.Hash_Set_Implementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using _04.Hash_Table_Implementation;


    public class HashSet<T> : IHashSet<T>, IEnumerable<T> where T : IComparable<T>
    {
        //Here is mine hash table from previous task
        private readonly HashTable<T, bool> elements;
        private const string NullCollectionExceptionText = "Collection cannot be null.";

        public HashSet()
        {
            this.elements = new HashTable<T, bool>();
        }

        public HashSet(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(NullCollectionExceptionText);
            }

            this.elements = new HashTable<T, bool>();

            foreach (var item in collection)
            {
                this.Add(item);
            }
        }

        public bool Add(T item)
        {
            if (this.elements.ContainsKey(item))
            {
                return false;
            }

            this.elements.Add(item, true);
            return true;
        }

        public bool Contains(T item)
        {
            return this.elements.ContainsKey(item) && this.elements[item];
        }


        public void Remove(T item)
        {
            this.elements.Remove(item);
        }

        public int Count
        {
            get { return this.elements.Count; }
        }

        public void Clear()
        {
            this.elements.Clear();
        }

        public void UnionWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            foreach (T item in other)
            {
                this.Add(item);
            }
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            foreach (T item in other)
            {
                if (!this.Contains(item))
                {
                    this.Remove(item);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.elements.Select(keyValuePair => keyValuePair.Key).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            var result = string.Join(", ", this.elements.Keys);
            return result;
        }
    }
}