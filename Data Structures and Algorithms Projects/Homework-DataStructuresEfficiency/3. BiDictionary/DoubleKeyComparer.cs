namespace BiDictionary
{
    using System;
    using System.Collections.Generic;

    internal class DoubleKeyComparer<TKey1, TKey2> : IEqualityComparer<Tuple<TKey1, TKey2>>
    {
        public bool Equals(Tuple<TKey1, TKey2> first, Tuple<TKey1, TKey2> second)
        {
            return first.Item1.Equals(second.Item1) && first.Item2.Equals(second.Item2);
        }

        public int GetHashCode(Tuple<TKey1, TKey2> doubleKey)
        {
            unchecked
            {
                int hash = 17;

                hash = hash * 23 + doubleKey.Item1.GetHashCode();
                hash = hash * 23 + doubleKey.Item2.GetHashCode();

                return hash;
            }
        }
    }
}
