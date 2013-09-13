namespace CrowdSourcedNews.Repositories
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
            this.context.SaveChanges();
            return item;
        }

        public T Update(int id, T item)
        {
            T entity = this.entitiesSet.Find(id);
            if (entity != null)
            {
                this.context.Entry<T>(entity).CurrentValues.SetValues(item);
            }
            else
            {
                this.Add(item);
            }

            this.context.SaveChanges();

            return item;
        }

        public bool Delete(int id)
        {
            T entity = this.entitiesSet.Find(id);
            if (entity != null)
            {
                this.entitiesSet.Remove(entity);
                this.context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
