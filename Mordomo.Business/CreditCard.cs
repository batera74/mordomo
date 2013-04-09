using Mordomo.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Business
{
    public class CreditCard : ICreditCard
    {
        public IRepositoryFactory repFactory
        {
            get;
            set;
        }

        public CreditCard(IRepositoryFactory repFactory)
        {
            this.repFactory = repFactory;
        }

        public Entities.CreditCard Save(Entities.CreditCard entity)
        {
            return Save(entity, false);
        }

        public virtual Entities.CreditCard Save(IEnumerable<Entities.CreditCard> entities)
        {
            return Save(entities, false).FirstOrDefault();
        }

        public virtual Entities.CreditCard Save(Entities.CreditCard entity, bool saveNestedProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.CreditCard>();
            return repository.Save(entity, saveNestedProperties);
        }

        public virtual IEnumerable<Entities.CreditCard> Save(IEnumerable<Entities.CreditCard> entities, bool saveNestedProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.CreditCard>();
            return repository.Save(entities, saveNestedProperties);
        }

        public virtual void Delete(Entities.CreditCard entity)
        {
            var repository = repFactory.GetGenericRepository<Entities.CreditCard>();
            repository.Delete(entity);
        }

        public virtual IEnumerable<Entities.CreditCard> Query(Func<Entities.CreditCard, bool> query)
        {
            var repository = repFactory.GetGenericRepository<Entities.CreditCard>();
            return repository.Query(query);
        }

        public virtual IEnumerable<Entities.CreditCard> Query(Func<Entities.CreditCard, bool> query, params string[] includeProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.CreditCard>();
            return repository.Query(query, includeProperties);
        }

        public virtual Entities.CreditCard Get(int id)
        {
            return this.Query(u => u.Id == id).FirstOrDefault();
        }

        public virtual IEnumerable<Entities.CreditCard> GetAll(params string[] includeProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.CreditCard>();
            return repository.GetAll(includeProperties);
        }
    }
}
