namespace Queue.Common
{
    using System;
    using System.Collections;
    using LinkedList.Common;

    public class Queue<T> : System.Collections.Generic.IEnumerable<T>
    {
        private LinkedList<T> queue;

        public Queue()
        {
            this.queue = new LinkedList<T>();
        }

        public int Count
        {
            get { return this.queue.Count; }
        }

        public void Enqueue(T value)
        {
            this.queue.Add(value);
        }

        public T Dequeue()
        {
            if (this.queue.Count == 0)
            {
                throw new InvalidOperationException("Cannot dequeue from an empty queue!");
            }

            T itemToDequeue = this.Peek();

            this.queue.RemoveAt(0);

            return itemToDequeue;
        }

        public T Peek()
        {
            if (this.queue.Count == 0)
            {
                throw new InvalidOperationException("Cannot peek from an empty queue!");
            }
            
            return this.queue[0];
        }

        public void Clear()
        {
            this.queue = new LinkedList<T>();
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            return this.queue.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
