namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection", "Collection to sort cannot be null!");
            }

            IList<T> sortedCollection = this.MergeSort(collection);

            collection.Clear();
            foreach (T item in sortedCollection)
            {
                collection.Add(item);
            }
        }

        private IList<T> MergeSort(IList<T> collection)
        {
            if (collection.Count <= 1) // One or less elements are always sorted
            {
                return collection;
            }

            int middle = collection.Count / 2;

            IList<T> left = new List<T>(); // The elements to the middle
            for (int index = 0; index < middle; index++)
            {
                left.Add(collection[index]);
            }

            IList<T> right = new List<T>(); // Middle element and the rest
            for (int index = middle; index < collection.Count; index++)
            {
                right.Add(collection[index]);
            }

            left = this.MergeSort(left);
            right = this.MergeSort(right);

            return this.Merge(left, right);
        }

        private IList<T> Merge(IList<T> left, IList<T> right)
        {
            IList<T> mergedCollection = new List<T>();
            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left[0].CompareTo(right[0]) <= 0)
                    {
                        mergedCollection.Add(left[0]);
                        left.RemoveAt(0);
                    }
                    else
                    {
                        mergedCollection.Add(right[0]);
                        right.RemoveAt(0);
                    }
                }
                else if (right.Count > 0)
                {
                    mergedCollection.Add(right[0]);
                    right.RemoveAt(0);
                }
                else if (left.Count > 0)
                {
                    mergedCollection.Add(left[0]);
                    left.RemoveAt(0);
                }
            }

            return mergedCollection;
        }
    }
}
