using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Business.Repository
{
    public interface IRepositoryFactory
    {
        IRepository<T> GetGenericRepository<T>()
        where T : Entities.EntityBase;
    }
}
