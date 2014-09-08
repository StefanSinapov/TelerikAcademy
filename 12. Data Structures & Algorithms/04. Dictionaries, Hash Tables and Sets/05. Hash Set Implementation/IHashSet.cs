namespace _05.Hash_Set_Implementation
{
    using System.Collections.Generic;

    public interface IHashSet <in T>
    {
        bool Add(T item);

        bool Contains(T item);

        void Remove(T item);

        int Count { get; }

        void Clear();

        void UnionWith(IEnumerable<T> other);

        void IntersectWith(IEnumerable<T> other);
    }
}