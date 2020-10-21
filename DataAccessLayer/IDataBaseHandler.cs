using Db.Entities;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IDataBaseHandler<T>
        where T : BaseDbClass
    {
        IEnumerable<T> Get(int skip, int take);
        T Get(Guid id);
        Guid Add(T iDaoEntity);
        void Update(Guid id, T iDaoEntity);
        void Delete(Guid id);
    }
}
