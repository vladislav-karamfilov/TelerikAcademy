namespace HashSet.Common
{
    using System;
    using System.Collections.Generic;

    public interface IHashSet<T> : IEnumerable<T>
    {
        int Count { get; }

        void Add(T value);

        bool Remove(T value);

        bool Contains(T value);

        void Clear();

        void UnionWith(IEnumerable<T> other);

        void IntersectWith(IEnumerable<T> other);
    }
}
