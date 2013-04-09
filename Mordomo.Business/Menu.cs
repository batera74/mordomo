using Mordomo.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Business
{
    public class Menu : IMenu
    {
        public IRepositoryFactory repFactory
        {
            get;
            set;
        }

        public Menu(IRepositoryFactory repFactory)
        {
            this.repFactory = repFactory;
        }

        public Entities.Menu Save(Entities.Menu entity)
        {
            return Save(entity, false);
        }

        public virtual Entities.Menu Save(IEnumerable<Entities.Menu> entities)
        {
            return Save(entities, false).FirstOrDefault();
        }

        public virtual Entities.Menu Save(Entities.Menu entity, bool saveNestedProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.Menu>();
            return repository.Save(entity, saveNestedProperties);
        }

        public virtual IEnumerable<Entities.Menu> Save(IEnumerable<Entities.Menu> entities, bool saveNestedProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.Menu>();
            return repository.Save(entities, saveNestedProperties);
        }

        public virtual void Delete(Entities.Menu entity)
        {
            var repository = repFactory.GetGenericRepository<Entities.Menu>();
            repository.Delete(entity);
        }

        public virtual IEnumerable<Entities.Menu> Query(Func<Entities.Menu, bool> query)
        {
            var repository = repFactory.GetGenericRepository<Entities.Menu>();
            return repository.Query(query);
        }

        public virtual IEnumerable<Entities.Menu> Query(Func<Entities.Menu, bool> query, params string[] includeProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.Menu>();
            return repository.Query(query, includeProperties);
        }

        public virtual Entities.Menu Get(int id)
        {
            return this.Query(u => u.Id == id).FirstOrDefault();
        }

        public virtual IEnumerable<Entities.Menu> GetAll(params string[] includeProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.Menu>();
            return repository.GetAll(includeProperties);
        }
    }
}
