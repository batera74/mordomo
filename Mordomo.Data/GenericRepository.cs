using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Mordomo.Data
{
    public class GenericRepository<T, C> : Business.Repository.IRepository<T>
        where T : Entities.EntityBase
        where C : DbContext, new()
    {
        protected C DataContext { get; set; }

        public GenericRepository()
        {
            DataContext = new C();       
        }

        private enum RepositoryAction
        {
            None,
            Updating,
            Inserting,
            Deleting,
            Searching
        }

        private RepositoryAction _currentAction;

        /// <summary>
        /// Save data into database.
        /// </summary>
        /// <param name="entity">Entity to save.</param>
        /// <returns>Entity saved.</returns>
        public virtual T Save(T entity)
        {
            return Save(entity, false);
        }

        /// <summary>
        /// Save data into database.
        /// </summary>
        /// <param name="entities">Entities to save.</param>
        /// <returns>Entity saved.</returns>
        public virtual T Save(IEnumerable<T> entities)
        {
            return Save(entities, false).FirstOrDefault();
        }

        /// <summary>
        /// Save data into database.
        /// </summary>
        /// <param name="entity">Entity to save.</param>c
        /// <param name="saveNestedProperties">Indicated repopsitory needs update nested properties</param>
        /// <returns>Entity saved.</returns>
        public virtual T Save(T entity, bool saveNestedProperties)
        {
            return Save(new T[] { entity }, saveNestedProperties).FirstOrDefault();
        }

        /// <summary>
        /// Save data into database.
        /// </summary>
        /// <param name="entities">Entities to save.</param>c
        /// <param name="saveNestedProperties">Indicated repopsitory needs update nested properties</param>
        /// <returns>Entity saved.</returns>
        public virtual IEnumerable<T> Save(IEnumerable<T> entities, bool saveNestedProperties)
        {
            using (DataContext)
            {
                foreach (var entity in entities)
                {
                    // Identity primary key value.
                    int primaryKeyValue = IdentityPrimaryKeyValue(entity, DataContext);

                    // Identify current action
                    this._currentAction = primaryKeyValue == 0 ? RepositoryAction.Inserting : RepositoryAction.Updating;
                    
                    // Save entity to database.
                    SaveEntity(entity, DataContext, primaryKeyValue);

                    // Update nested properties
                    UpdateNestedProperties(entity, DataContext, saveNestedProperties);
                }

                // Commit changes to database
                DataContext.SaveChanges();
            }

            return entities;
        }

        private void UpdateNestedProperties(T entity, DbContext context, bool saveNestedProperties)
        {
            Type typeGeneric = entity.GetType();

            foreach (var property in typeGeneric.GetProperties())
            {
                if (IsEntityProperty(property) && property.PropertyType != typeof(Byte[]))
                {   
                    if(property.PropertyType.IsArray || property.GetValue(entity, null) is IEnumerable<object>)
                    {
                        IEnumerable<object> itensOfArray = (IEnumerable<object>)property.GetValue(entity, null);

                        if (itensOfArray != null)
                        {
                            foreach (var itemOfArray in itensOfArray)
                            {
                                SetStateOfEntity(itemOfArray, DataContext, saveNestedProperties, entity);
                            }
                        }
                    }
                    else
                    {
                        var nestedPropertyToUpdate = property.GetValue(entity, null);

                        if (nestedPropertyToUpdate != null)
                        {
                            SetStateOfEntity(nestedPropertyToUpdate, DataContext, saveNestedProperties, entity);
                        }
                    }
                }
            }
        }

        private bool IsEntityProperty(PropertyInfo property)
        {
            return property.PropertyType.IsClass && property.PropertyType != typeof(string);
        }

        private void SetNestedPropertiesStatus(object entity, DbContext context, EntityState state, object parent)
        {
            Type typeGeneric = entity.GetType();

            foreach (var property in typeGeneric.GetProperties())
            {
                if (IsEntityProperty(property))
                {
                    if (property.PropertyType.IsArray || property.GetValue(entity, null) is IEnumerable<object>)
                    {
                        IEnumerable<object> itensOfArray = (IEnumerable<object>)property.GetValue(entity, null);

                        if (itensOfArray != null)
                        {
                            foreach (object itemOfArray in itensOfArray)
                            {
                                int nestedPropertyPrimaryKeyValue = IdentityPrimaryKeyValue(itemOfArray, DataContext);
                                
                                if (itemOfArray != parent)
                                {
                                    var currentStatus = DataContext.Entry(itemOfArray).State;

                                    if (!(nestedPropertyPrimaryKeyValue == 0 && currentStatus == EntityState.Added))
                                    {
                                        DataContext.Entry(itemOfArray).State = state;
                                        SetNestedPropertiesStatus(itemOfArray, DataContext, state, entity);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        var nestedPropertyToUpdate = property.GetValue(entity, null);

                        if (nestedPropertyToUpdate != null)
                        {
                            if (nestedPropertyToUpdate != parent)
                            {
                                DataContext.Entry(nestedPropertyToUpdate).State = state;

                                SetNestedPropertiesStatus(nestedPropertyToUpdate, DataContext, state, entity);
                            }
                        }
                    }
                }
            }
        }

        private void SetStateOfEntity(object entity, DbContext context, bool saveNestedProperties, object parent)
        {
            EntityState targetState = EntityState.Added;            

            // Capture ID value from nested property
            int nestedPropertyPrimaryKeyValue = IdentityPrimaryKeyValue(entity, DataContext);
            //((Entities.EntityBase)entity).LastUpdate = DateTime.Now;

            // Actions during insert
            if (this._currentAction == RepositoryAction.Inserting)
            {
                // Verify if property needs to be added or stay as unchanged
                if (nestedPropertyPrimaryKeyValue == 0)
                    targetState = saveNestedProperties ? EntityState.Added : EntityState.Unchanged;
                else
                    targetState = EntityState.Unchanged;
            }
            // Actions during update
            else if (this._currentAction == RepositoryAction.Updating)
            {
                // If nestedPropertyPrimaryKeyValue equals zero, so this instance must be added
                if (nestedPropertyPrimaryKeyValue == 0)
                    targetState = saveNestedProperties ? EntityState.Added : EntityState.Unchanged;
                else
                    targetState = saveNestedProperties ? EntityState.Modified : EntityState.Unchanged;
            }

            DataContext.Entry(entity).State = targetState;

            if (targetState == EntityState.Unchanged)
                SetNestedPropertiesStatus(entity, DataContext, targetState, parent);
        }

        private void SaveEntity(T entity, DbContext context, int currentPrimaryKeyValue)
        {
            if (currentPrimaryKeyValue == 0)
                DataContext.Set<T>().Add(entity);
            else
                DataContext.Entry(entity).State = EntityState.Modified;
        }

        private int IdentityPrimaryKeyValue(object entity, DbContext context)
        {
            int returnValue = 0;
            var primaryKeyProperties = GetKeyNames(context);

            Type typeGeneric = entity.GetType();

            var primaryKeyProperty = typeGeneric.GetProperties().Where(p => string.Compare(p.Name, primaryKeyProperties[0], true) == 0).FirstOrDefault();

            if (primaryKeyProperty != null)
            {
                returnValue = (int)primaryKeyProperty.GetValue(entity, null);
            }

            return returnValue;
        }

        private string[] GetKeyNames(DbContext context)
        {
            ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
            ObjectSet<T> set = objectContext.CreateObjectSet<T>();
            IEnumerable<string> keyNames = set.EntitySet.ElementType
                                                        .KeyMembers
                                                        .Select(k => k.Name);

            return keyNames.ToArray();
        }

        public void Delete(T entity)
        {
            this._currentAction = RepositoryAction.Deleting;

            using (DataContext)
            {
                DataContext.Set<T>().Attach(entity);
                DataContext.Set<T>().Remove(entity);

                DataContext.SaveChanges();
            }
        }

        public IEnumerable<T> Query(Func<T, bool> query)
        {
            this._currentAction = RepositoryAction.Searching;

            return Query(query, null);
        }

        public IEnumerable<T> GetAll(params string[] includeProperties)
        {
            this._currentAction = RepositoryAction.Searching;

            IEnumerable<T> result = null;

            // Create database context
            using (DataContext)
            {
                // Create instance of DbSet
                var dbSet = DataContext.Set<T>();

                DbQuery<T> currentQuery = null;

                // Verify if the user wants to use includes
                if (includeProperties != null && includeProperties.Count() > 0)
                {
                    foreach (string propertyInclude in includeProperties)
                    {
                        // Add includes to query...
                        if (currentQuery == null)
                            currentQuery = dbSet.Include(propertyInclude);
                        else
                            currentQuery.Include(propertyInclude);
                    }

                    result = currentQuery;
                }
                else
                {
                    result = dbSet;
                }

                result = result.ToList();
            }

            return result;
        }

        public IEnumerable<T> Query(Func<T, bool> query, params string[] includeProperties)
        {
            this._currentAction = RepositoryAction.Searching;

            IEnumerable<T> result = null;

            // Create database context
            using (DataContext)
            {
                // Create instance of DbSet
                var dbSet = DataContext.Set<T>();

                DbQuery<T> currentQuery = null;

                // Verify if the user wants to use includes
                if (includeProperties != null && includeProperties.Count() > 0)
                {
                    foreach (string propertyInclude in includeProperties)
                    {
                        // Add includes to query...
                        if (currentQuery == null)
                            currentQuery = dbSet.Include(propertyInclude);
                        else
                            currentQuery.Include(propertyInclude);
                    }
                }

                // Execute query
                if (currentQuery == null)
                    result = dbSet.Where(query);
                else
                    result = currentQuery.Where(query);

                result = result.ToList();
            }

            return result;
        }
    }
}
