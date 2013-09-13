namespace CrowdSourcedNews.Repositories
{
    using System.Linq;

    public interface IRepository<T> where T : class
    {
        T Get(int id);

        IQueryable<T> GetAll();

        T Add(T item);

        T Update(int id, T item);

        bool Delete(int id);
    }
}
