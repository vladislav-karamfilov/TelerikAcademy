namespace SchoolsSystem.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    public class InMemoryRepository<T> : IRepository<T> where T : class
    {
        private readonly IList<T> inMemoryRepository;

        public InMemoryRepository()
        {
            this.inMemoryRepository = new List<T>();
        }

        public T Get(int id)
        {
            return this.inMemoryRepository[id];
        }

        public IQueryable<T> GetAll()
        {
            return this.inMemoryRepository.AsQueryable<T>();
        }

        public T Add(T item)
        {
            this.inMemoryRepository.Add(item);
            return item;
        }
    }
}
