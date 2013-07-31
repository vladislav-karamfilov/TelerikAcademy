namespace PriorityQueue.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    internal class BinaryHeap<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private IList<T> heap;

        public BinaryHeap()
        {
            this.heap = new List<T>();
        }

        public int Count
        {
            get
            {
                return this.heap.Count;
            }
        }

        public void Add(T item)
        {
            this.heap.Add(item);

            int index = this.Count - 1;
            int parentIndex = GetParentIndex(index);
            while (index > 0 &&
                this.heap[parentIndex].CompareTo(this.heap[index]) < 0)
            {
                T swapValue = this.heap[index];
                this.heap[index] = this.heap[parentIndex];
                this.heap[parentIndex] = swapValue;

                index = parentIndex;
                parentIndex = GetParentIndex(index);
            }
        }

        public T GetMaxItem()
        {
            return this.heap[0];
        }

        public T ExtractMaxItem()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException(
                    "Cannot get the maximum item of an empty binary heap!");
            }

            T maxItem = this.heap[0];
            this.heap[0] = this.heap[this.Count - 1];
            this.heap.RemoveAt(this.Count - 1);

            this.MaxHeapify(0);

            return maxItem;
        }

        public void Clear()
        {
            this.heap = new List<T>();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.heap.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private static int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private static int GetLeftChildIndex(int index)
        {
            return index * 2 + 1;
        }

        private static int GetRightChildIndex(int index)
        {
            return index * 2 + 2;
        }

        private void MaxHeapify(int index)
        {
            int leftChildIndex = GetLeftChildIndex(index);
            int rightChildIndex = GetRightChildIndex(index);
            
            int largestItemIndex = 0;
            if (leftChildIndex < this.Count &&
                this.heap[leftChildIndex].CompareTo(this.heap[index]) > 0)
            {
                largestItemIndex = leftChildIndex;
            }
            else
            {
                largestItemIndex = index;
            }

            if (rightChildIndex < this.Count &&
                this.heap[rightChildIndex].CompareTo(this.heap[largestItemIndex]) > 0)
            {
                largestItemIndex = rightChildIndex;
            }

            if (largestItemIndex != index)
            {
                T swapValue = this.heap[index];
                this.heap[index] = this.heap[largestItemIndex];
                this.heap[largestItemIndex] = swapValue;

                this.MaxHeapify(largestItemIndex);
            }
        }
    }
}
