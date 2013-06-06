namespace IteratorExample
{
    using System.Collections.Generic;

    public class Aggregate<T> : IAggregate<T>
    {
        private IIterator<T> iterator;

        public Aggregate()
        {
            this.CreateIterator();
        }

        public IIterator<T> CreateIterator()
        {
            if (this.iterator == null)
            {
                this.iterator = new Iterator<T>(this);
            }

            return this.iterator;
        }

        public IList<T> GetAll()
        {
            IList<T> list = new List<T>();
            list.Add(this.iterator.First());
            while (!this.iterator.HasNext())
            {
                list.Add(this.iterator.Next());
            }

            return list;
        }

        public void AddItem(T item)
        {
            this.iterator.AddItem(item);
        }
    }
}
