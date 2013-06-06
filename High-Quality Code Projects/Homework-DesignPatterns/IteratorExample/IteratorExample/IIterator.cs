namespace IteratorExample
{
    public interface IIterator<T>
    {
        T First();
        T Next();
        T CurrentItem();
        bool HasNext();
        void AddItem(T item);
    }
}
