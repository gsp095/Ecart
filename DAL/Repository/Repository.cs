using DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
   public class Repository<T> : IRepository<T> where T :class
    {
        private ProductListEntities  entities = null;
        public Repository(ProductListEntities _entities)
        {
            entities = _entities;
            entities.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return entities.Set<T>();

        }

        public T Get(Func<T, bool> predicate)
        {
            return entities.Set<T>().First(predicate);
        }

        public void Add(T entity)
        {
            entities.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            entities.Entry(entity).State = EntityState.Modified;
                    
        }

        public void Delete(T entity)
        {
            entities.Set<T>().Remove(entity);
        }
        public void Save()
        {
            entities.SaveChanges();
        }
    }
}
