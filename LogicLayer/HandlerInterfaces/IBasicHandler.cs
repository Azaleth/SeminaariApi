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
        Guid Add(T IEntity);
        void Update(Guid id, T IEntity);
        void Delete(Guid id);
    }
}
