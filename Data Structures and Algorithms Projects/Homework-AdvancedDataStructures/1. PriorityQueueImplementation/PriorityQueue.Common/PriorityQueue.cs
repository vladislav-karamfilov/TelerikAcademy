namespace PriorityQueue.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class PriorityQueue<T> : IPriorityQueue<T>
        where T : IComparable<T>
    {
        private BinaryHeap<T> queue;

        public PriorityQueue()
        {
            this.queue = new BinaryHeap<T>();
        }

        public int Count
        {
            get 
            {
                return this.queue.Count;
            }
        }

        public void Enqueue(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(
                    "item",
                    "Cannot enqueue a null item to a priority queue!");
            }

            this.queue.Add(item);
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException(
                    "Cannot peak from an empty priority queue!");
            }

            return this.queue.GetMaxItem();
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException(
                    "Cannot dequeue from an empty priority queue!");
            }

            return this.queue.ExtractMaxItem();
        }

        public void Clear()
        {
            this.queue = new BinaryHeap<T>();
        }

        public IEnumerator<T> GetEnumerator()
        {
            BinaryHeap<T> heapToEnumerate = new BinaryHeap<T>();
            foreach (T item in this.queue)
            {
                heapToEnumerate.Add(item);
            }

            while (heapToEnumerate.Count > 0)
            {
                yield return heapToEnumerate.ExtractMaxItem();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
