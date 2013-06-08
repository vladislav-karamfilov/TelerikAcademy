namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    
    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection", "Collection to sort cannot be null!");
            }

            this.QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(IList<T> collection, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            int partitionIndex = this.Partition(collection, startIndex, endIndex);
            this.QuickSort(collection, startIndex, partitionIndex - 1);
            this.QuickSort(collection, partitionIndex + 1, endIndex);
        }

        private int Partition(IList<T> collection, int startIndex, int endIndex)
        {
            T pivot = collection[endIndex];
            int index1 = startIndex - 1;
            for (int index2 = startIndex; index2 < endIndex; index2++)
            {
                if (collection[index2].CompareTo(pivot) < 0)
                {
                    index1++;

                    T temp = collection[index1];
                    collection[index1] = collection[index2];
                    collection[index2] = temp;
                }
            }

            T temp1 = collection[index1 + 1];
            collection[index1 + 1] = collection[endIndex];
            collection[endIndex] = temp1;

            return index1 + 1;
        }
    }
}
