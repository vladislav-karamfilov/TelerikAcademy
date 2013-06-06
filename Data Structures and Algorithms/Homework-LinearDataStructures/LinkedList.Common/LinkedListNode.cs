namespace LinkedList.Common
{
    using System;

    internal class LinkedListNode<T>
    {
        private T value;
        private LinkedListNode<T> next;

        public LinkedListNode(T value)
        {
            this.Value = value;
            this.Next = null;
        }

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public LinkedListNode<T> Next
        {
            get { return this.next; }
            set { this.next = value; }
        }
    }
}
