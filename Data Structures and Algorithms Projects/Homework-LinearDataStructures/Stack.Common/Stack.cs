namespace Stack.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;

        private T[] stack;
        private int topIndex;

        public Stack()
        {
            this.stack = new T[0];
            this.topIndex = -1;
        }

        public int Count
        {
            get { return this.topIndex + 1; }
        }

        private int Capacity
        {
            get { return this.stack.Length; }
        }

        public void Push(T value)
        {
            if (this.Capacity == 0)
            {
                this.stack = new T[InitialCapacity];
            }

            if (this.Count + 1 > this.Capacity)
            {
                this.DoubleCapacity();
            }

            this.topIndex++;
            this.stack[this.topIndex] = value;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot pop from empty stack!");
            }

            T itemToPop = this.Peek();

            this.stack[this.topIndex] = default(T);
            this.topIndex--;

            return itemToPop;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot peek from empty stack!");
            }

            return this.stack[this.topIndex];
        }

        public void Clear()
        {
            this.stack = new T[0];
            this.topIndex = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void DoubleCapacity()
        {
            T[] newStack = new T[this.Count * 2];
            Array.Copy(this.stack, newStack, this.Count);
            this.stack = newStack;
        }
    }
}
