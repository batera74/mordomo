using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mordomo.Business.Repository;

namespace Mordomo.Business
{
    public class CreditCardType : ICreditCardType
    {
        public IRepositoryFactory repFactory
        {
            get;
            set;
        }

        public CreditCardType(IRepositoryFactory repFactory)
        {
            this.repFactory = repFactory;
        }

        public Entities.CreditCardType Save(Entities.CreditCardType entity)
        {
            return Save(entity, false);
        }

        public virtual Entities.CreditCardType Save(IEnumerable<Entities.CreditCardType> entities)
        {
            return Save(entities, false).FirstOrDefault();
        }

        public virtual Entities.CreditCardType Save(Entities.CreditCardType entity, bool saveNestedProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.CreditCardType>();
            return repository.Save(entity, saveNestedProperties);
        }

        public virtual IEnumerable<Entities.CreditCardType> Save(IEnumerable<Entities.CreditCardType> entities, bool saveNestedProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.CreditCardType>();
            return repository.Save(entities, saveNestedProperties);
        }

        public virtual void Delete(Entities.CreditCardType entity)
        {
            var repository = repFactory.GetGenericRepository<Entities.CreditCardType>();
            repository.Delete(entity);
        }

        public virtual IEnumerable<Entities.CreditCardType> Query(Func<Entities.CreditCardType, bool> query)
        {
            var repository = repFactory.GetGenericRepository<Entities.CreditCardType>();
            return repository.Query(query);
        }

        public virtual IEnumerable<Entities.CreditCardType> Query(Func<Entities.CreditCardType, bool> query, params string[] includeProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.CreditCardType>();
            return repository.Query(query, includeProperties);
        }

        public virtual Entities.CreditCardType Get(int id)
        {
            return this.Query(u => u.Id == id).FirstOrDefault();
        }

        public virtual IEnumerable<Entities.CreditCardType> GetAll(params string[] includeProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.CreditCardType>();
            return repository.GetAll(includeProperties);
        }
    }
}
