using Mordomo.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Business
{
    public class AndressType : IAndressType
    {
        public IRepositoryFactory repFactory
        {
            get;
            set;
        }

        public AndressType(IRepositoryFactory repFactory)
        {
            this.repFactory = repFactory;
        }

        public Entities.AndressType Save(Entities.AndressType entity)
        {
            return Save(entity, false);
        }

        public virtual Entities.AndressType Save(IEnumerable<Entities.AndressType> entities)
        {
            return Save(entities, false).FirstOrDefault();
        }

        public virtual Entities.AndressType Save(Entities.AndressType entity, bool saveNestedProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.AndressType>();
            return repository.Save(entity, saveNestedProperties);
        }

        public virtual IEnumerable<Entities.AndressType> Save(IEnumerable<Entities.AndressType> entities, bool saveNestedProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.AndressType>();
            return repository.Save(entities, saveNestedProperties);
        }

        public virtual void Delete(Entities.AndressType entity)
        {
            var repository = repFactory.GetGenericRepository<Entities.AndressType>();
            repository.Delete(entity);
        }

        public virtual IEnumerable<Entities.AndressType> Query(Func<Entities.AndressType, bool> query)
        {
            var repository = repFactory.GetGenericRepository<Entities.AndressType>();
            return repository.Query(query);
        }

        public virtual IEnumerable<Entities.AndressType> Query(Func<Entities.AndressType, bool> query, params string[] includeProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.AndressType>();
            return repository.Query(query, includeProperties);
        }

        public virtual Entities.AndressType Get(int id)
        {
            return this.Query(u => u.Id == id).FirstOrDefault();
        }

        public virtual IEnumerable<Entities.AndressType> GetAll(params string[] includeProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.AndressType>();
            return repository.GetAll(includeProperties);
        }
    }
}
