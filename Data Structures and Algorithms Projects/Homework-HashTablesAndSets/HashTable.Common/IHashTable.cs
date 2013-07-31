namespace HashTable.Common
{
    using System;
    using System.Collections.Generic;

    public interface IHashTable<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        int Count { get; }

        TValue this[TKey key] { get; set; }

        ICollection<TKey> Keys { get; }

        ICollection<TValue> Values { get; }

        void Add(TKey key, TValue value);

        bool Remove(TKey key);

        KeyValuePair<TKey, TValue> Find(TKey key);

        bool ContainsKey(TKey key);

        void Clear();
    }
}
