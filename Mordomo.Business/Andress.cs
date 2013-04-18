using Mordomo.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Business
{
    public class Andress : IAndress
    {
        public IRepositoryFactory repFactory
        {
            get;
            set;
        }

        public Andress(IRepositoryFactory repFactory)
        {
            this.repFactory = repFactory;
        }

        public Entities.Andress Save(Entities.Andress entity)
        {
            return Save(entity, false);
        }

        public virtual Entities.Andress Save(IEnumerable<Entities.Andress> entities)
        {
            return Save(entities, false).FirstOrDefault();
        }

        public virtual Entities.Andress Save(Entities.Andress entity, bool saveNestedProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.Andress>();
            return repository.Save(entity, saveNestedProperties);
        }

        public virtual IEnumerable<Entities.Andress> Save(IEnumerable<Entities.Andress> entities, bool saveNestedProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.Andress>();
            return repository.Save(entities, saveNestedProperties);
        }

        public virtual void Delete(Entities.Andress entity)
        {
            var repository = repFactory.GetGenericRepository<Entities.Andress>();
            repository.Delete(entity);
        }

        public virtual IEnumerable<Entities.Andress> Query(Func<Entities.Andress, bool> query)
        {
            var repository = repFactory.GetGenericRepository<Entities.Andress>();
            return repository.Query(query);
        }

        public virtual IEnumerable<Entities.Andress> Query(Func<Entities.Andress, bool> query, params string[] includeProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.Andress>();
            return repository.Query(query, includeProperties);
        }

        public virtual Entities.Andress Get(int id)
        {
            return this.Query(u => u.Id == id).FirstOrDefault();
        }

        public virtual IEnumerable<Entities.Andress> GetAll(params string[] includeProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.Andress>();
            return repository.GetAll(includeProperties);
        }
    }
}
