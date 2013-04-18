using Mordomo.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Business
{
    public class City : ICity
    {
        public IRepositoryFactory repFactory
        {
            get;
            set;
        }

        public City(IRepositoryFactory repFactory)
        {
            this.repFactory = repFactory;
        }

        public Entities.City Save(Entities.City entity)
        {
            return Save(entity, false);
        }

        public virtual Entities.City Save(IEnumerable<Entities.City> entities)
        {
            return Save(entities, false).FirstOrDefault();
        }

        public virtual Entities.City Save(Entities.City entity, bool saveNestedProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.City>();
            return repository.Save(entity, saveNestedProperties);
        }

        public virtual IEnumerable<Entities.City> Save(IEnumerable<Entities.City> entities, bool saveNestedProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.City>();
            return repository.Save(entities, saveNestedProperties);
        }

        public virtual void Delete(Entities.City entity)
        {
            var repository = repFactory.GetGenericRepository<Entities.City>();
            repository.Delete(entity);
        }

        public virtual IEnumerable<Entities.City> Query(Func<Entities.City, bool> query)
        {
            var repository = repFactory.GetGenericRepository<Entities.City>();
            return repository.Query(query);
        }

        public virtual IEnumerable<Entities.City> Query(Func<Entities.City, bool> query, params string[] includeProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.City>();
            return repository.Query(query, includeProperties);
        }

        public virtual Entities.City Get(int id)
        {
            return this.Query(u => u.Id == id).FirstOrDefault();
        }

        public virtual IEnumerable<Entities.City> GetAll(params string[] includeProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.City>();
            return repository.GetAll(includeProperties);
        }
    }
}
