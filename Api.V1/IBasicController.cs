using System;
using System.Collections.Generic;

namespace Api.V1
{
    interface IBasicController<T>
    {
        IEnumerable<T> Get(int skip, int take);    
        T Get(Guid id);
        Guid Post(T value);
        void Put(Guid id, T value);
        void Delete(Guid id);
    }
}
