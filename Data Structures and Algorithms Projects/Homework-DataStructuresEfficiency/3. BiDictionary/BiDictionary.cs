namespace BiDictionary
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class BiDictionary<TKey1, TKey2, TValue>
    {
        private const bool AllowDuplicates = true;

        private MultiDictionary<TKey1, TValue> byFirstKey;
        private MultiDictionary<TKey2, TValue> bySecondKey;
        private MultiDictionary<Tuple<TKey1, TKey2>, TValue> byBothKeys;

        public BiDictionary()
        {
            this.byFirstKey = new MultiDictionary<TKey1, TValue>(AllowDuplicates);
            this.bySecondKey = new MultiDictionary<TKey2, TValue>(AllowDuplicates);
            this.byBothKeys = new MultiDictionary<Tuple<TKey1, TKey2>, TValue>(
                AllowDuplicates,
                new DoubleKeyComparer<TKey1, TKey2>());
        }

        public ICollection<TValue> GetByFirstKey(TKey1 key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key", "Cannot get values with key null!");
            }

            return this.byFirstKey[key];
        }

        public ICollection<TValue> GetBySecondKey(TKey2 key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key", "Cannot get values with key null!");
            }

            return this.bySecondKey[key];
        }

        public ICollection<TValue> GetByBothKeys(TKey1 key1, TKey2 key2)
        {
            if (key1 == null)
            {
                throw new ArgumentNullException("key1", "Cannot get values with key null!");
            }

            if (key2 == null)
            {
                throw new ArgumentNullException("key2", "Cannot get values with key null!");
            }

            return this.byBothKeys[new Tuple<TKey1, TKey2>(key1, key2)];
        }

        public int Count
        {
            get
            {
                return this.byBothKeys.KeyValuePairs.Count;
            }
        }

        public void Add(TKey1 key1, TKey2 key2, TValue value)
        {
            if (key1 == null)
            {
                throw new ArgumentNullException("key1", "Cannot add values with key null!");
            }

            if (key2 == null)
            {
                throw new ArgumentNullException("key2", "Cannot add values with key null!");
            }

            this.byFirstKey.Add(key1, value);
            this.bySecondKey.Add(key2, value);
            this.byBothKeys.Add(new Tuple<TKey1, TKey2>(key1, key2), value);
        }

        public bool Remove(TKey1 key1, TKey2 key2)
        {
            if (key1 == null)
            {
                throw new ArgumentNullException("key1", "Cannot remove values with key null!");
            }

            if (key2 == null)
            {
                throw new ArgumentNullException("key2", "Cannot remove values with key null!");
            }

            ICollection<TValue> entriesByBothKeys = this.GetByBothKeys(key1, key2);
            this.byFirstKey.Remove(new KeyValuePair<TKey1, ICollection<TValue>>(key1, entriesByBothKeys));
            this.bySecondKey.Remove(new KeyValuePair<TKey2, ICollection<TValue>>(key2, entriesByBothKeys));
            return this.byBothKeys.Remove(new Tuple<TKey1, TKey2>(key1, key2));
        }

        public void Clear()
        {
            this.byFirstKey = new MultiDictionary<TKey1, TValue>(AllowDuplicates);
            this.bySecondKey = new MultiDictionary<TKey2, TValue>(AllowDuplicates);
            this.byBothKeys = new MultiDictionary<Tuple<TKey1, TKey2>, TValue>(AllowDuplicates);
        }
    }
}
