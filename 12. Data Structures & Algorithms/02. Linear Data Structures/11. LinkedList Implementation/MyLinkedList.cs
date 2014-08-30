namespace _11.LinkedList_Implementation
{
    using System.Collections;
    using System.Collections.Generic;

    public class MyLinkedList<T> : IEnumerable
    {

        public MyLinkedList()
        {
        }

        public ListItem<T> First { get; set; }

        public ListItem<T> Last { get; set; }

        public int Count;

        public void AddFirst(T value)
        {
            var newListItem = new ListItem<T>(value);

            if (this.First == null)
            {
                this.First = this.Last = newListItem;
            }
            else
            {
                newListItem.Next = this.First;
                this.First.Previous = newListItem;
                this.First = newListItem;
            }

            Count++;
        }

        public void AddLast(T value)
        {
            var newListItem = new ListItem<T>(value);

            if (this.Last == null)
            {
                this.First = this.Last = newListItem;
            }
            else
            {
                newListItem.Previous = this.Last;
                this.Last.Next = newListItem;
                this.Last = newListItem;
            }

            this.Count++;
        }

        public void AddBefore(ListItem<T> item, T value)
        {
            if (item == null)
            {
                return;
            }

            var newitem = new ListItem<T>(value);

            if (item.Previous == null)
            {
                item.Previous = newitem;
                newitem.Next = item;
            }
            else
            {
                newitem.Next = item;
                newitem.Previous = item.Previous;

                item.Previous.Next = newitem;
                item.Previous = newitem;
            }

            if (item == this.First)
            {
                this.First = newitem;
            }

            this.Count++;
        }

        public void AddAfter(ListItem<T> item, T value)
        {
            if (item == null)
            {
                return;
            }

            var newitem = new ListItem<T>(value);

            if (item.Next == null)
            {
                item.Next = newitem;
                newitem.Previous = item;
            }
            else
            {
                newitem.Next = item.Next;
                newitem.Previous = item;

                item.Next.Previous = newitem;
                item.Next = newitem;
            }

            if (item == this.Last)
            {
                this.Last = newitem;
            }

            this.Count++;
        }

        public void Remove(T value)
        {
            var item = this.Find(value);
            this.RemoveReference(ref item);
        }

        public void RemoveFirst()
        {
            var item = this.First;
            this.RemoveReference(ref item);
        }

        public void RemoveLast()
        {
            var item = this.Last;
            this.RemoveReference(ref item);
        }


        public ListItem<T> Find(T value)
        {
            var currentItem = this.First;
            while (currentItem.Next != null)
            {
                if (currentItem.Value.Equals(value))
                {
                    return currentItem;
                }
                currentItem = currentItem.Next;
            }

            return null;
        }

        public ListItem<T> FindLast(T value)
        {
            var currentItem = this.Last;

            while (currentItem != null)
            {
                if (currentItem.Value.Equals(value))
                {
                    return currentItem;
                }

                currentItem = currentItem.Previous;
            }

            return null;
        }

        public void Clear()
        {
            this.First = null;
            this.Count = 0;
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            var currentNode = this.First;

            while (currentNode != null)
            {
                yield return currentNode.Value;

                currentNode = currentNode.Next;
            }
        }

        private void RemoveReference(ref ListItem<T> item)
        {
            if (item != null)
            {
                if (item.Previous != null)
                {
                    item.Previous.Next = item.Next;
                }

                if (item.Next != null)
                {
                    item.Next.Previous = item.Previous;
                }

                if (item == this.First)
                {
                    this.First = item.Next;
                }

                if (item == this.Last)
                {
                    this.Last = item.Previous;
                }

                item = null;

                this.Count--;
            }
        }
    }
}