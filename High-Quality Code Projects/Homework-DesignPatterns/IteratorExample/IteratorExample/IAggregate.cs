namespace IteratorExample
{
    using System.Collections.Generic;

    public interface IAggregate<T>
    {
        IIterator<T> CreateIterator();
        IList<T> GetAll();
        void AddItem(T item);
    }
}
