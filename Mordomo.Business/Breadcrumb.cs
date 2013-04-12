using Mordomo.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Business
{
    public class Breadcrumb : IBreadcrumb
    {
        public IRepositoryFactory repFactory
        {
            get;
            set;
        }

        public Breadcrumb(IRepositoryFactory repFactory)
        {
            this.repFactory = repFactory;
        }

        public Entities.Breadcrumb Save(Entities.Breadcrumb entity)
        {
            return Save(entity, false);
        }

        public virtual Entities.Breadcrumb Save(IEnumerable<Entities.Breadcrumb> entities)
        {
            return Save(entities, false).FirstOrDefault();
        }

        public virtual Entities.Breadcrumb Save(Entities.Breadcrumb entity, bool saveNestedProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.Breadcrumb>();
            return repository.Save(entity, saveNestedProperties);
        }

        public virtual IEnumerable<Entities.Breadcrumb> Save(IEnumerable<Entities.Breadcrumb> entities, bool saveNestedProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.Breadcrumb>();
            return repository.Save(entities, saveNestedProperties);
        }

        public virtual void Delete(Entities.Breadcrumb entity)
        {
            var repository = repFactory.GetGenericRepository<Entities.Breadcrumb>();
            repository.Delete(entity);
        }

        public virtual IEnumerable<Entities.Breadcrumb> Query(Func<Entities.Breadcrumb, bool> query)
        {
            var repository = repFactory.GetGenericRepository<Entities.Breadcrumb>();
            return repository.Query(query);
        }

        public virtual IEnumerable<Entities.Breadcrumb> Query(Func<Entities.Breadcrumb, bool> query, params string[] includeProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.Breadcrumb>();
            return repository.Query(query, includeProperties);
        }

        public virtual Entities.Breadcrumb Get(int id)
        {
            return this.Query(u => u.Id == id).FirstOrDefault();
        }

        public virtual IEnumerable<Entities.Breadcrumb> GetAll(params string[] includeProperties)
        {
            var repository = repFactory.GetGenericRepository<Entities.Breadcrumb>();
            return repository.GetAll(includeProperties);
        }
    }
}
