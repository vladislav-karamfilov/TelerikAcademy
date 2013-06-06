namespace LinkedList.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    public class LinkedList<T> : IEnumerable<T>
    {
        #region Private fields
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;
        private int count;
        #endregion

        #region Constructor
        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }
        #endregion

        #region Properties
        public int Count
        {
            get { return this.count; }
        }

        public T First
        {
            get 
            {
                if (this.head == null)
                {
                    throw new InvalidOperationException("The list is empty - has no first element!");
                }

                return this.head.Value; 
            }
        }

        public T Last
        {
            get
            {
                if (this.tail == null)
                {
                    throw new InvalidOperationException("The list is empty - has no last element!");
                }

                return this.tail.Value; 
            }
        }
        #endregion

        #region Indexer
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.count)
                {
                    throw new IndexOutOfRangeException("Index is out of the boundaries of the list!");
                }

                LinkedListNode<T> nodeToGet = GetNodeAt(index);
                return nodeToGet.Value;
            }

            set
            {
                if (index < 0 || index >= this.count)
                {
                    throw new IndexOutOfRangeException("Index is out of the boundaries of the list!");
                }

                LinkedListNode<T> nodeToSet = GetNodeAt(index);
                nodeToSet.Value = value;
            }
        }
        #endregion

        #region Methods
        public void Add(T value)
        {
            if (this.head != null)
            {
                this.tail.Next = new LinkedListNode<T>(value);
                this.tail = this.tail.Next;
            }
            else
            {
                this.head = new LinkedListNode<T>(value);
                this.tail = this.head;
            }

            this.count++;
        }

        public bool Remove(T value)
        {
            if (this.head == null)
            {
                return false;
            }

            if (this.head.Value.Equals(value))
            {
                this.head = this.head.Next;
                if (this.count == 1)
                {
                    this.tail = null;
                }

                this.count--;
                return true;
            }

            LinkedListNode<T> currentNode = this.head;
            while (currentNode.Next != null && !currentNode.Next.Value.Equals(value))
            {
                currentNode = currentNode.Next;
            }

            if (currentNode.Next != null)
            {
                if (currentNode.Next.Equals(this.tail))
                {
                    this.tail = currentNode;
                    this.tail.Next = null;
                }
                else
                {
                    currentNode.Next = currentNode.Next.Next;
                }

                this.count--;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException("Index is out of the boundaries of the list!");
            }

            if (index == 0)
            {
                this.head = this.head.Next;
                if (this.count == 1)
                {
                    this.tail = null;
                }
            }
            else
            {
                LinkedListNode<T> previousOfNodeToDelete = GetNodeAt(index - 1);
                if (index != this.count - 1)
                {
                    previousOfNodeToDelete.Next = previousOfNodeToDelete.Next.Next;
                }
                else
                {
                    this.tail = previousOfNodeToDelete;
                    this.tail.Next = null;
                }
            }

            this.count--;
            return true;
        }

        public void Clear()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public int IndexOf(T value)
        {
            int currentIndex = 0;
            LinkedListNode<T> currentNode = this.head;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    return currentIndex;
                }

                currentIndex++;
                currentNode = currentNode.Next;
            }

            return -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion

        #region Private methods
        private LinkedListNode<T> GetNodeAt(int index)
        {
            int currentIndex = 0;
            LinkedListNode<T> currentNode = this.head;
            while (currentIndex < index)
            {
                currentNode = currentNode.Next;
                currentIndex++;
            }

            return currentNode;
        }
        #endregion
    }
}
