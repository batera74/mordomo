using Mordomo.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Business
{
    public class State : IState
    {
        public IRepositoryFactory repFactory
        {
            get;
            set;
        }

        public State(IRepositoryFactory repFactory)
        {
            this.repFactory = repFactory;
        }

        public Entities.State Save(Entities.State entity)
        {
            return Save(entity, false);
        }

        public virtual Entities.State Save(IEnumerable<Entities.State> entities)
        {
            return Save(entities, false).FirstOrDefault();
        }

        public virtual Entities.State Save(Entities.State entity, bool saveNestedProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.State>();
            return repository.Save(entity, saveNestedProperties);
        }

        public virtual IEnumerable<Entities.State> Save(IEnumerable<Entities.State> entities, bool saveNestedProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.State>();
            return repository.Save(entities, saveNestedProperties);
        }

        public virtual void Delete(Entities.State entity)
        {
            var repository = repFactory.GetGenericRepository<Entities.State>();
            repository.Delete(entity);
        }

        public virtual IEnumerable<Entities.State> Query(Func<Entities.State, bool> query)
        {
            var repository = repFactory.GetGenericRepository<Entities.State>();
            return repository.Query(query);
        }

        public virtual IEnumerable<Entities.State> Query(Func<Entities.State, bool> query, params string[] includeProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.State>();
            return repository.Query(query, includeProperties);
        }

        public virtual Entities.State Get(int id)
        {
            return this.Query(u => u.Id == id).FirstOrDefault();
        }

        public virtual IEnumerable<Entities.State> GetAll(params string[] includeProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.State>();
            return repository.GetAll(includeProperties);
        }
    }
}
