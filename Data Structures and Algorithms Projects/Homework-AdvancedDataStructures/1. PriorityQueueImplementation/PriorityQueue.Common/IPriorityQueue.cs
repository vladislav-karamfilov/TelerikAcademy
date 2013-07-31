namespace PriorityQueue.Common
{
    using System;
    using System.Collections.Generic;

    public interface IPriorityQueue<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        int Count { get; }

        void Enqueue(T item);

        T Peek();

        T Dequeue();

        void Clear();
    }
}
