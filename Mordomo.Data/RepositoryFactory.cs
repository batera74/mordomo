using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Data
{
    public class RepositoryFactory : Business.Repository.IRepositoryFactory
    {
        public Business.Repository.IRepository<T> GetGenericRepository<T>()
            where T : Entities.EntityBase
        {
            return new GenericRepository<T, MordomoContext>();
        }
    }
}
