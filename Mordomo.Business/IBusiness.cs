using Mordomo.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Business
{
    public interface IBusiness<T>
    {
        IRepositoryFactory repFactory { get; set; }

        T Save(T entity);

        T Save(IEnumerable<T> entities);

        T Save(T entity, bool saveNestedProperties);

        IEnumerable<T> Save(IEnumerable<T> entities, bool saveNestedProperties);

        void Delete(T entity);

        IEnumerable<T> Query(Func<T, bool> query);

        IEnumerable<T> Query(Func<T, bool> query, params string[] includeProperties);

        T Get(int id);

        IEnumerable<T> GetAll(params string[] includeProperties);
    }
}
