using Mordomo.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Business
{
    public abstract class Business<T> where T : Entities.EntityBase
    {
        protected readonly IRepositoryFactory repFactory;

        public Business(IRepositoryFactory repFactory)
        {
            this.repFactory = repFactory;
        }

        public T Save(T entity)
        {
            return Save(entity, false);
        }

        public virtual T Save(IEnumerable<T> entities)
        {
            return Save(entities, false).FirstOrDefault();
        }

        public virtual T Save(T entity, bool saveNestedProperties)
        {
            var repository = repFactory.GetGenericRepository<T>();
            return repository.Save(entity, saveNestedProperties);
        }

        public virtual IEnumerable<T> Save(IEnumerable<T> entities, bool saveNestedProperties)
        {
            var repository = repFactory.GetGenericRepository<T>();
            return repository.Save(entities, saveNestedProperties);
        }

        public virtual void Delete(T entity)
        {
            var repository = repFactory.GetGenericRepository<T>();
            repository.Delete(entity);
        }

        public virtual IEnumerable<T> Query(Func<T, bool> query)
        {
            var repository = repFactory.GetGenericRepository<T>();
            return repository.Query(query);
        }

        public virtual IEnumerable<T> Query(Func<T, bool> query, params string[] includeProperties)
        {
            var repository = repFactory.GetGenericRepository<T>();
            return repository.Query(query, includeProperties);
        }

        public virtual T Get(int id)
        {
            return this.Query(t => t.Id == id).FirstOrDefault();
        }

        public virtual IEnumerable<T> GetAll(params string[] includeProperties)
        {
            var repository = repFactory.GetGenericRepository<T>();
            return repository.GetAll(includeProperties);
        }
    }
}
