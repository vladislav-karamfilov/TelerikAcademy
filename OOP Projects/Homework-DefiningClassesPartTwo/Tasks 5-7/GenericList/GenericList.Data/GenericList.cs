using System;
using System.Text;

namespace GenericList.Data
{
    public class GenericList<T>
    {
        #region Instance fields
        private T[] list;
        private int count;
        #endregion

        #region Properties
        public int Count
        {
            get { return count; }
        }
        public int Capacity
        {
            get { return this.list.Length; }
        }
        #endregion

        #region Constructors
        public GenericList()
        {
            this.list = new T[0];
            this.count = 0;
        }
        public GenericList(int capacity) 
        {
            this.list = new T[capacity];
            this.count = 0;
        }
        #endregion

        #region Methods
        public void Add(T item)
        {
            if (this.Capacity == 0)
            {
                this.list = new T[4];
            }
            if (this.count < this.Capacity)
            {
                this.list[count] = item;
            }
            else
            {
                T[] newList = new T[this.Capacity * 2];
                for (int index = 0; index < this.count; index++)
                {
                    newList[index] = list[index];
                }
                newList[this.count] = item;
                this.list = newList;
            }
            this.count++;
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.count)
                {
                    throw new IndexOutOfRangeException("Invalid list index! Index out of list boundaries provided!");
                }
                return this.list[index];
            }
            set
            {
                if (index < 0 || index >= this.count)
                {
                    throw new IndexOutOfRangeException("Invalid list index! Index out of list boundaries provided!");
                }
                this.list[index] = value;
            }
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException("Invalid list index! Index out of list boundaries provided");
            }
            T[] newList = new T[this.Capacity];
            for (int index1 = 0; index1 < index; index1++)
            {
                newList[index1] = this.list[index1];
            }
            for (int index2 = index + 1; index2 < this.count; index2++)
            {
                newList[index2 - 1] = this.list[index2];
            }
            this.list = newList;
            this.count--;
        }
        public void InsertAt(T item, int index)
        {
            if (index < 0 || index > this.count)
            {
                throw new IndexOutOfRangeException("Invalid list index! Index out of list boundaries provided");
            }
            if (index == this.count) // The item is being inserted at the end of the list
            {
                this.Add(item);
                return;
            }
            T[] newList;
            if (this.count == this.Capacity)
            {
                newList = new T[this.count * 2];
            }
            else
            {
                newList = new T[this.Capacity];
            }
            for (int index1 = 0; index1 < index; index1++)
            {
                newList[index1] = this.list[index1];
            }
            newList[index] = item;
            for (int index2 = index + 1; index2 <= this.count; index2++)
            {
                newList[index2] = this.list[index2 - 1];
            }
            this.list = newList;
            this.count++;
        }
        public void Clear()
        {
            if (this.Capacity > 0)
            {
                this.list = new T[0];
                this.count = 0;
            }
        }
        public int Find(T item)
        {
            for (int index = 0; index < this.count; index++)
            {
                if (this.list[index].Equals(item))
                {
                    return index;
                }
            }
            return -1;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("[");
            for (int index = 0; index < this.count - 1; index++)
            {
                result.Append(this.list[index] + ", ");
            }
            result.Append(this.list[count - 1] + "]");
            return result.ToString();
        }
        #endregion
    }
}
