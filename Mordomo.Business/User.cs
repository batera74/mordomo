using Mordomo.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Business
{
    public class User : IUser
    {
        public IRepositoryFactory repFactory
        {
            get;
            set;
        }

        public User(IRepositoryFactory repFactory)
        {
            this.repFactory = repFactory;
        }

        public Entities.User Save(Entities.User entity)
        {
            return Save(entity, false);
        }

        public virtual Entities.User Save(IEnumerable<Entities.User> entities)
        {
            return Save(entities, false).FirstOrDefault();
        }

        public virtual Entities.User Save(Entities.User entity, bool saveNestedProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.User>();
            return repository.Save(entity, saveNestedProperties);
        }

        public virtual IEnumerable<Entities.User> Save(IEnumerable<Entities.User> entities, bool saveNestedProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.User>();
            return repository.Save(entities, saveNestedProperties);
        }

        public virtual void Delete(Entities.User entity)
        {
            var repository = repFactory.GetGenericRepository<Entities.User>();
            repository.Delete(entity);
        }

        public virtual IEnumerable<Entities.User> Query(Func<Entities.User, bool> query)
        {
            var repository = repFactory.GetGenericRepository<Entities.User>();
            return repository.Query(query);
        }

        public virtual IEnumerable<Entities.User> Query(Func<Entities.User, bool> query, params string[] includeProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.User>();
            return repository.Query(query, includeProperties);
        }

        public virtual Entities.User Get(int id)
        {
            return this.Query(u => u.Id == id).FirstOrDefault();
        }

        public virtual IEnumerable<Entities.User> GetAll(params string[] includeProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.User>();
            return repository.GetAll(includeProperties);
        }
    }
}
