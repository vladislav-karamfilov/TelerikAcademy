namespace HashTable.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class HashTable<TKey, TValue> : IHashTable<TKey, TValue>
    {
        private const int InitialCapacity = 16;
        private const float MaxLoad = 0.75f;

        private LinkedList<KeyValuePair<TKey, TValue>>[] chains;
        private float currentLoad;
        private int count;
        private int filledChainsCount;

        public HashTable()
            : this(InitialCapacity)
        {
        }

        public HashTable(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(
                    "capacity",
                    "Cannot create a hash table with negative capacity!");
            }

            this.chains = new LinkedList<KeyValuePair<TKey, TValue>>[capacity];
            this.currentLoad = 0.0f;
            this.count = 0;
            this.filledChainsCount = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                KeyValuePair<TKey, TValue> entry = this.Find(key);
                return entry.Value;
            }

            set
            {
                int hashCode = key.GetHashCode() & int.MaxValue; // Keep the hash code positive
                int chainIndex = hashCode % this.chains.Length;
                if (this.chains[chainIndex] != null)
                {
                    int entriesCount = this.chains[chainIndex].Count;
                    for (int i = 0; i < entriesCount; i++)
                    {
                        LinkedListNode<KeyValuePair<TKey, TValue>> currentNode =
                            GetNodeAt(i, this.chains[chainIndex]);
                        if (currentNode.Value.Key.Equals(key))
                        {
                            currentNode.Value = new KeyValuePair<TKey, TValue>(key, value);
                            return;
                        }
                    }
                }

                throw new KeyNotFoundException("Specified key not found in the hash table!");
            }
        }

        private LinkedListNode<KeyValuePair<TKey, TValue>> GetNodeAt(
            int index,
            LinkedList<KeyValuePair<TKey, TValue>> list)
        {
            LinkedListNode<KeyValuePair<TKey, TValue>> currentNode = list.First;
            int currentIndex = 1;
            while (currentIndex < index)
            {
                currentNode = currentNode.Next;
            }

            return currentNode;
        }

        public ICollection<TKey> Keys
        {
            get
            {
                IList<TKey> keys = new List<TKey>(this.count);
                foreach (LinkedList<KeyValuePair<TKey, TValue>> chain in this.chains)
                {
                    if (chain != null)
                    {
                        foreach (KeyValuePair<TKey, TValue> entry in chain)
                        {
                            keys.Add(entry.Key);
                        }
                    }
                }

                return keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                IList<TValue> values = new List<TValue>(this.count);
                foreach (LinkedList<KeyValuePair<TKey, TValue>> chain in this.chains)
                {
                    if (chain != null)
                    {
                        foreach (KeyValuePair<TKey, TValue> entry in chain)
                        {
                            values.Add(entry.Value);
                        }
                    }
                }

                return values;
            }
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key", "The key of an item cannot be null!");
            }

            int hashCode = key.GetHashCode() & int.MaxValue; // Keep the hash code positive
            int chainIndex = hashCode % this.chains.Length;
            if (this.chains[chainIndex] != null)
            {
                foreach (KeyValuePair<TKey, TValue> entry in this.chains[chainIndex])
                {
                    if (entry.Key.Equals(key))
                    {
                        throw new ArgumentException(
                            "An item with the same key is already in the hash table!",
                            "key");
                    }
                }
            }
            else
            {
                this.chains[chainIndex] = new LinkedList<KeyValuePair<TKey, TValue>>();
                this.filledChainsCount++;
            }

            KeyValuePair<TKey, TValue> newEntry = new KeyValuePair<TKey, TValue>(key, value);
            this.chains[chainIndex].AddLast(newEntry);

            this.count++;

            this.currentLoad = (float)this.filledChainsCount / this.chains.Length;
            if (this.currentLoad > MaxLoad)
            {
                this.DoubleCapacity();
            }
        }

        public bool Remove(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key", "The key of an item cannot be null!");
            }

            int hashCode = key.GetHashCode() & int.MaxValue; // Keep the hash code positive
            int chainIndex = hashCode % this.chains.Length;
            if (this.chains[chainIndex] != null)
            {
                foreach (KeyValuePair<TKey, TValue> entry in this.chains[chainIndex])
                {
                    if (entry.Key.Equals(key))
                    {
                        this.chains[chainIndex].Remove(entry);
                        this.count--;
                        return true;
                    }
                }
            }

            return false;
        }

        public KeyValuePair<TKey, TValue> Find(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key", "The key of an item cannot be null!");
            }

            int hashCode = key.GetHashCode() & int.MaxValue; // Keep the hash code positive
            int chainIndex = hashCode % this.chains.Length;
            if (this.chains[chainIndex] != null)
            {
                foreach (KeyValuePair<TKey, TValue> entry in this.chains[chainIndex])
                {
                    if (entry.Key.Equals(key))
                    {
                        return entry;
                    }
                }
            }

            throw new KeyNotFoundException("Specified key not found in the hash table!");
        }

        public bool ContainsKey(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key", "The key of an item cannot be null!");
            }

            int hashCode = key.GetHashCode() & int.MaxValue; // Keep the hash code positive
            int chainIndex = hashCode % this.chains.Length;

            if (this.chains[chainIndex] != null)
            {
                foreach (KeyValuePair<TKey, TValue> entry in this.chains[chainIndex])
                {
                    if (entry.Key.Equals(key))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void Clear()
        {
            this.chains = new LinkedList<KeyValuePair<TKey, TValue>>[InitialCapacity];
            this.currentLoad = 0.0f;
            this.count = 0;
            this.filledChainsCount = 0;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (LinkedList<KeyValuePair<TKey, TValue>> chain in this.chains)
            {
                if (chain != null)
                {
                    foreach (KeyValuePair<TKey, TValue> entry in chain)
                    {
                        yield return entry;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void DoubleCapacity()
        {
            int newCapacity = this.chains.Length * 2;
            LinkedList<KeyValuePair<TKey, TValue>>[] oldChains = this.chains;
            this.chains = new LinkedList<KeyValuePair<TKey, TValue>>[newCapacity];
            foreach (LinkedList<KeyValuePair<TKey, TValue>> chain in oldChains)
            {
                if (chain != null)
                {
                    foreach (KeyValuePair<TKey, TValue> entry in chain)
                    {
                        int hashCode = entry.Key.GetHashCode() & int.MaxValue; // Keep the hash code positive
                        int newChainIndex = hashCode % this.chains.Length;
                        if (this.chains[newChainIndex] == null)
                        {
                            this.chains[newChainIndex] = new LinkedList<KeyValuePair<TKey, TValue>>();
                        }

                        this.chains[newChainIndex].AddLast(entry);
                    }
                }
            }
        }
    }
}
