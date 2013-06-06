namespace SortingPerformanceComparison
{
    using System;

    public static class Sorter<T> 
        where T : IComparable<T>
    {
        #region Quicksort
        public static void QuickSort(T[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        private static void QuickSort(T[] array, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            int partitionIndex = Partition(array, startIndex, endIndex);
            QuickSort(array, startIndex, partitionIndex - 1);
            QuickSort(array, partitionIndex + 1, endIndex);
        }

        // Arranging the subarray around a pivot -> less than pivot elements, pivot element and greater than pivot elements
        private static int Partition(T[] array, int startIndex, int endIndex)
        {
            T pivot = array[endIndex];
            int index = startIndex - 1;
            for (int i = startIndex; i < endIndex; i++)
            {
                if (array[i].CompareTo(pivot) < 0)
                {
                    index++;
                    SwapElements(array, index, i);
                }
            }

            SwapElements(array, index + 1, endIndex);
            return index + 1;
        }

        private static void SwapElements(T[] array, int index1, int index2)
        {
            T swapElement = array[index1];
            array[index1] = array[index2];
            array[index2] = swapElement;
        }
        #endregion

        #region Selection sort
        public static void SelectionSort(T[] array)
        {
            int length = array.Length;

            // Getting the smallest element from the subarray and moving it to the first position and repeating
            for (int index = 0; index < length - 1; index++)
            {
                int minElementIndex = index;
                for (int index2 = index + 1; index2 < length; index2++)
                {
                    if (array[index2].CompareTo(array[minElementIndex]) < 0)
                    {
                        minElementIndex = index2;
                    }
                }

                // A change of the indexes exist => exchange them
                if (minElementIndex != index)
                {
                    T swapElement = array[index];
                    array[index] = array[minElementIndex];
                    array[minElementIndex] = swapElement;
                }
            }
        }
        #endregion

        #region Insertion sort
        public static void InsertionSort(T[] array)
        {
            T currentElement = default(T);
            int length = array.Length;
            int index = 0;
            for (int i = 0; i < length; i++)
            {
                currentElement = array[i];
                index = i - 1;
                while (index >= 0 && currentElement.CompareTo(array[index]) < 0)
                {
                    array[index + 1] = array[index];
                    index--;
                }

                array[index + 1] = currentElement;
            }
        }
        #endregion
    }
}
