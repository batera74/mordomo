using Mordomo.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Business
{
    public class Page : IPage
    {
        public IRepositoryFactory repFactory
        {
            get;
            set;
        }

        public Page(IRepositoryFactory repFactory)
        {
            this.repFactory = repFactory;
        }

        public Entities.Page Save(Entities.Page entity)
        {
            return Save(entity, false);
        }

        public virtual Entities.Page Save(IEnumerable<Entities.Page> entities)
        {
            return Save(entities, false).FirstOrDefault();
        }

        public virtual Entities.Page Save(Entities.Page entity, bool saveNestedProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.Page>();
            return repository.Save(entity, saveNestedProperties);
        }

        public virtual IEnumerable<Entities.Page> Save(IEnumerable<Entities.Page> entities, bool saveNestedProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.Page>();
            return repository.Save(entities, saveNestedProperties);
        }

        public virtual void Delete(Entities.Page entity)
        {
            var repository = repFactory.GetGenericRepository<Entities.Page>();
            repository.Delete(entity);
        }

        public virtual IEnumerable<Entities.Page> Query(Func<Entities.Page, bool> query)
        {
            var repository = repFactory.GetGenericRepository<Entities.Page>();
            return repository.Query(query);
        }

        public virtual IEnumerable<Entities.Page> Query(Func<Entities.Page, bool> query, params string[] includeProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.Page>();
            return repository.Query(query, includeProperties);
        }

        public virtual Entities.Page Get(int id)
        {
            return this.Query(u => u.Id == id).FirstOrDefault();
        }

        public virtual IEnumerable<Entities.Page> GetAll(params string[] includeProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.Page>();
            return repository.GetAll(includeProperties);
        }
    }
}
