namespace _04.Hash_Table_Implementation
{
    using System.Collections.Generic;

    public interface IHashTable<TKey, TValue>
    {
        int Count { get; }

        ICollection<TKey> Keys { get; }

        TValue this[TKey key] { get; set; }

        void Add(TKey key, TValue value);

        TValue GetValue(TKey key);

        bool Remove(TKey key);

        void Clear();
    }
}