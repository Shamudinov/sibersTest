using Microsoft.EntityFrameworkCore;
using SibersTest.DAL.DbContext;
using System.Collections.Generic;
using System.Linq;

namespace SibersTest.DAL.Repositories
{
    public abstract class RepositoryBase<T> where T : class
    {
        protected DatabaseContext dataContext;
        private readonly DbSet<T> dbSet;

        protected RepositoryBase(DatabaseContext dataContext)
        {
            this.dataContext = dataContext;
            dbSet = dataContext.Set<T>();
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }
        public virtual void Update(T entity)
        {
            dbSet.Update(entity);
        }
        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }
        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }
        public virtual T GetById(string id)
        {
            return dbSet.Find(id);
        }
    }
}
