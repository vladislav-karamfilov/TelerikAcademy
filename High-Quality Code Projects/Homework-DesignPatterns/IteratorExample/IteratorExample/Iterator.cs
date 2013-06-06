namespace IteratorExample
{
    using System;
    using System.Collections.Generic;

    public class Iterator<T> : IIterator<T>
    {
        private readonly IList<T> collection = new List<T>(); 
        private readonly IAggregate<T> aggregate;
        private int current = 0;

        public Iterator(IAggregate<T> aggregate)
        {
            this.aggregate = aggregate;
        }

        public T First()
        {
            this.current = 0;
            return this.collection[this.current];
        }

        public T Next()
        {
            this.current++;
            return this.collection[this.current];
        }

        public T CurrentItem()
        {
            return this.collection[this.current];
        }

        public bool HasNext()
        {
            return this.current == this.collection.Count - 1;
        }

        public void AddItem(T item)
        {
            this.collection.Add(item);
        }
    }
}
