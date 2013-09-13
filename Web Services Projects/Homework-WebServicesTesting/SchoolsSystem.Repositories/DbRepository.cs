namespace SchoolsSystem.Repositories
{
    using System.Data.Entity;
    using System.Linq;

    public class DbRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext context;
        private readonly IDbSet<T> entitiesSet;

        public DbRepository(DbContext context)
        {
            this.context = context;
            this.entitiesSet = this.context.Set<T>();
        }

        public T Get(int id)
        {
            T entity = this.entitiesSet.Find(id);
            return entity;
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> allEntities = this.entitiesSet;
            return allEntities;
        }

        public T Add(T item)
        {
            this.entitiesSet.Add(item);
            return item;
        }
    }
}
