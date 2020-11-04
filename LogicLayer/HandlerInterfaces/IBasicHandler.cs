using Api.Entities;
using System;
using System.Collections.Generic;

namespace LogicLayer.HandlerInterfaces
{
    public interface IBasicHandler<T>
        where T : BaseEntity
    {
        IEnumerable<T> Get(int skip, int take);
        T Get(Guid id);
        Guid Insert(T apiEntity);
        void Update(Guid id, T apiEntity);
        void Delete(Guid id);
    }
}
