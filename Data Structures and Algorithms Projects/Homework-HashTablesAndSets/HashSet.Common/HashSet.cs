namespace HashSet.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using HashTable.Common;

    public class HashSet<T> : IHashSet<T>
    {
        private const int InitialCapacity = 16;

        private HashTable<T, T> set;

        public HashSet()
            : this(InitialCapacity)
        {
        }

        public HashSet(int capacity)
        {
            this.set = new HashTable<T, T>(capacity);
        }

        public HashSet(IEnumerable<T> items)
        {
            this.set = new HashTable<T, T>(InitialCapacity);
            foreach (T item in items)
            {
                this.set.Add(item, item);
            }
        }

        public int Count
        {
            get
            {
                return this.set.Count;
            }
        }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item", "A set cannot contain null item!");
            }

            if (this.set.ContainsKey(item))
            {
                throw new InvalidOperationException("Cannot add duplicate element to a set!");
            }

            this.set.Add(item, item);
        }

        public bool Remove(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item", "Cannot remove null item from a set!");
            }

            return this.set.Remove(item);
        }

        public bool Contains(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item", "A set cannot contain null item!");
            }

            return this.set.ContainsKey(item);
        }

        public void Clear()
        {
            this.set = new HashTable<T, T>(InitialCapacity);
        }

        public void UnionWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other", "Cannot union with a null value!");
            }

            foreach (T item in other)
            {
                if (!this.set.ContainsKey(item))
                {
                    this.set.Add(item, item);
                }
            }
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other", "Cannot intersect with a null value!");
            }
            
            IList<T> intersectedItems = new List<T>();
            foreach (T item in other)
            {
                if (this.set.ContainsKey(item))
                {
                    intersectedItems.Add(item);
                }
            }

            this.set = new HashTable<T, T>(intersectedItems.Count);
            foreach (T item in intersectedItems)
            {
                this.set.Add(item, item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in this.set.Keys)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
