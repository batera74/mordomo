using Mordomo.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Business
{
    public class MenuItem : IMenuItem
    {
        
        public IRepositoryFactory repFactory
        {
            get;
            set;
        }

        public MenuItem(IRepositoryFactory repFactory)
        {
            this.repFactory = repFactory;
        }

        public Entities.MenuItem Save(Entities.MenuItem entity)
        {
            return Save(entity, false);
        }

        public virtual Entities.MenuItem Save(IEnumerable<Entities.MenuItem> entities)
        {
            return Save(entities, false).FirstOrDefault();
        }

        public virtual Entities.MenuItem Save(Entities.MenuItem entity, bool saveNestedProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.MenuItem>();
            return repository.Save(entity, saveNestedProperties);
        }

        public virtual IEnumerable<Entities.MenuItem> Save(IEnumerable<Entities.MenuItem> entities, bool saveNestedProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.MenuItem>();
            return repository.Save(entities, saveNestedProperties);
        }

        public virtual void Delete(Entities.MenuItem entity)
        {
            var repository = repFactory.GetGenericRepository<Entities.MenuItem>();
            repository.Delete(entity);
        }

        public virtual IEnumerable<Entities.MenuItem> Query(Func<Entities.MenuItem, bool> query)
        {
            var repository = repFactory.GetGenericRepository<Entities.MenuItem>();
            return repository.Query(query);
        }

        public virtual IEnumerable<Entities.MenuItem> Query(Func<Entities.MenuItem, bool> query, params string[] includeProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.MenuItem>();
            return repository.Query(query, includeProperties);
        }

        public virtual Entities.MenuItem Get(int id)
        {
            return this.Query(u => u.Id == id).FirstOrDefault();
        }

        public virtual IEnumerable<Entities.MenuItem> GetAll(params string[] includeProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.MenuItem>();
            return repository.GetAll(includeProperties);
        }
    }
}
