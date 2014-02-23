//-----------------------------------------------------------------------
// <copyright file="GenericList.cs" company="Telerik Academy">
//     Telerik Academy
// </copyright>
// <author>Pesho Peshov</author>
//-----------------------------------------------------------------------
namespace GenericList.Data
{
    using System;
    using System.Text;

    /// <summary>
    /// Represents a list of elements of type T.
    /// </summary>
    /// <typeparam name="T">The type elements in the list.</typeparam>
    public class GenericList<T>
    {
        #region Instance fields
        private T[] list;
        private int count;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the amount of elements actually stored in the list.
        /// </summary>
        public int Count
        {
            get { return count; }
        }

        /// <summary>
        /// Gets the total number of elements the internal data structure currently holds.
        /// </summary>
        public int Capacity
        {
            get { return this.list.Length; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes an empty instance of <see cref="GenericList{T}"/>.
        /// </summary>
        public GenericList()
        {
            this.list = new T[0];
            this.count = 0;
        }

        /// <summary>
        /// Initializes an instance of <see cref="GenericList{T}"/> with specified <paramref name="capacity"/>.
        /// </summary>
        /// <param name="capacity">The initial <see cref="Capacity"/> of the instance to be created.</param>
        public GenericList(int capacity)
        {
            this.list = new T[capacity];
            this.count = 0;
        }

        /// <summary>
        /// Gets or sets the element at specified by <paramref name="index"/> position in the list.
        /// Throw a <exception cref="System.IndexOutOfRangeException">IndexOutOfRangeException</exception> if provided
        /// <paramref name="index"/> is out of the boundaries of the list.
        /// </summary>
        /// <param name="index">The position in the list of the element to be get/set.</param>
        /// <returns>The element at position <paramref name="index"/>.</returns>
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
        #endregion

        #region Methods
        /// <summary>
        /// Adds a new element to the current instance.
        /// </summary>
        /// <param name="element">The element to be added.</param>
        public void Add(T element)
        {
            if (this.Capacity == 0)
            {
                this.list = new T[4];
            }

            if (this.count < this.Capacity)
            {
                this.list[count] = element;
            }
            else
            {
                T[] newList = new T[this.Capacity * 2];
                for (int index = 0; index < this.count; index++)
                {
                    newList[index] = list[index];
                }

                newList[this.count] = element;
                this.list = newList;
            }

            this.count++;
        }

        /// <summary>
        /// Removes the elemnt at position <paramref name="index"/> in the list.
        /// Throw a <exception cref="System.IndexOutOfRangeException">IndexOutOfRangeException</exception> if provided 
        /// <paramref name="index"/> is out of the boundaries of the list.
        /// </summary>
        /// <param name="index">The position in the list of the element to be removed.</param>
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

        /// <summary>
        /// Inserts the provided <paramref name="element"/> at the specified by 
        /// <paramref name="index"/> position in the list. Throw a <exception cref="System.IndexOutOfRangeException">
        /// IndexOutOfRangeException</exception> if provided <paramref name="index"/> is out of the boundaries of the list.
        /// </summary>
        /// <param name="element">The element to be inserted.</param>
        /// <param name="index">The position in the list the <paramref name="element"/> to be inserted.</param>
        public void InsertAt(T element, int index)
        {
            if (index < 0 || index > this.count)
            {
                throw new IndexOutOfRangeException("Invalid list index! Index out of list boundaries provided");
            }

            if (index == this.count) // The item is being inserted at the end of the list
            {
                this.Add(element);
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

            newList[index] = element;
            for (int index2 = index + 1; index2 <= this.count; index2++)
            {
                newList[index2] = this.list[index2 - 1];
            }

            this.list = newList;
            this.count++;
        }

        /// <summary>
        /// Clears the list.
        /// </summary>
        public void Clear()
        {
            if (this.Capacity > 0)
            {
                this.list = new T[0];
                this.count = 0;
            }
        }

        /// <summary>
        /// Gets the index of the <paramref name="element"/> in the list.
        /// </summary>
        /// <param name="element">The element to be located in the list.</param>
        /// <returns>The index of the <paramref name="element"/> in the list.</returns>
        public int IndexOf(T element)
        {
            for (int index = 0; index < this.count; index++)
            {
                if (this.list[index].Equals(element))
                {
                    return index;
                }
            }

            return -1;
        }

        /// <summary>
        /// Gets the string representation of the list.
        /// </summary>
        /// <returns>The string representation of the list.</returns>
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
