using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mordomo.Entities;
using System.Linq.Expressions;

namespace Mordomo.Business.Repository
{
    public interface IRepository<T>
        where T : Entities.EntityBase
    {
        /// <summary>
        /// Save data into database.
        /// </summary>
        /// <param name="entity">Entity to save.</param>
        /// <returns>Entity saved.</returns>
        T Save(T entity);

        /// <summary>
        /// Save data into database.
        /// </summary>
        /// <param name="entities">Entities to save.</param>
        /// <returns>Entity saved.</returns>
        T Save(IEnumerable<T> entities);

        /// <summary>
        /// Save data into database.
        /// </summary>
        /// <param name="entities">Entities to save.</param>
        /// <returns>Entity saved.</returns>
        T Save(T entity, bool saveNestedProperties);

        /// <summary>
        /// Save data into database.
        /// </summary>
        /// <param name="entities">Entities to save.</param>c
        /// <param name="saveNestedProperties">Indicated repopsitory needs update nested properties</param>
        /// <returns>Entity saved.</returns>
        IEnumerable<T> Save(IEnumerable<T> entities, bool saveNestedProperties);

        void Delete(T entity);
        IEnumerable<T> Query(Func<T, bool> query);
        IEnumerable<T> GetAll(params string[] includeProperties);
        IEnumerable<T> Query(Func<T, bool> query, params string[] includeProperties);
    }
}
