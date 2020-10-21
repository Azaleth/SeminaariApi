using Api.Entities;
using DataAccessLayer;
using Db.Entities;
using LogicLayer.HandlerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer.Handlers
{
    public abstract class BaseHandler<API_ENTITY, DB_ENTITY> : IBasicHandler<API_ENTITY>
        where API_ENTITY : BaseEntity
        where DB_ENTITY : BaseDbClass
    {
        internal abstract API_ENTITY Convert(DB_ENTITY dbEntity);
        internal abstract DB_ENTITY Convert(API_ENTITY apiEntity);
        internal IEnumerable<API_ENTITY> Convert(IEnumerable<DB_ENTITY> dbEntities)
        {
            List<API_ENTITY> students = new List<API_ENTITY>();
            foreach (var item in dbEntities)
                students.Add(Convert(item));
            return students;
        }
        internal IEnumerable<DB_ENTITY> Convert(IEnumerable<API_ENTITY> dbEntities)
        {
            List<DB_ENTITY> students = new List<DB_ENTITY>();
            foreach (var item in dbEntities)
                students.Add(Convert(item));
            return students;
        }

        protected BaseDataBaseHandler<DB_ENTITY> Handler => DataBaseHandlerFactory.GetHandler<DB_ENTITY>(typeof(DB_ENTITY));        

        public Guid Add(API_ENTITY IEntity)
        {
            return Handler.Add(Convert(IEntity));
        }

        public void Delete(Guid id)
        {
            Handler.Delete(id);
        }

        public IEnumerable<API_ENTITY> Get(int skip, int take)
        {
            return Convert((IEnumerable<DB_ENTITY>)Handler.Get(skip, take));
        }

        public API_ENTITY Get(Guid id)
        {
            return Convert((DB_ENTITY)Handler.Get(id));
        }

        public void Update(Guid id, API_ENTITY IEntity)
        {
            Handler.Update(id, Convert(IEntity));
        }        
    }
}
