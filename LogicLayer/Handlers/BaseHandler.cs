using Api.Entities;
using DataAccessLayer;
using LogicLayer.HandlerInterfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DB = Db.Entities;

//Allow test project access to internal functions
[assembly: InternalsVisibleTo("Api.UnitTests")]
namespace LogicLayer.Handlers
{

    public abstract class BaseHandler<API_ENTITY, DB_ENTITY> : IBasicHandler<API_ENTITY>
        where API_ENTITY : BaseEntity
        where DB_ENTITY : DB.BaseDbClass
    {
        internal abstract API_ENTITY Convert(DB_ENTITY dbEntity);
        internal abstract DB_ENTITY Convert(API_ENTITY apiEntity);
        protected virtual void Validate(API_ENTITY apiEntity) { }
        internal IEnumerable<API_ENTITY> Convert(IEnumerable<DB_ENTITY> dbEntities)
        {
            if (dbEntities == null)
                return null;
            List<API_ENTITY> apiEntities = new List<API_ENTITY>();
            foreach (var item in dbEntities)
                apiEntities.Add(Convert(item));
            return apiEntities;
        }
        internal IEnumerable<DB_ENTITY> Convert(IEnumerable<API_ENTITY> dbEntities)
        {
            List<DB_ENTITY> apiEntities = new List<DB_ENTITY>();
            foreach (var item in dbEntities)
                apiEntities.Add(Convert(item));
            return apiEntities;
        }

        protected BaseDataBaseHandler<DB_ENTITY> Handler => DataBaseHandlerFactory.GetHandler<DB_ENTITY>(typeof(DB_ENTITY));

        public Guid Insert(API_ENTITY apiEntity)
        {
            return Handler.Add(Convert(apiEntity));
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

        public void Update(Guid id, API_ENTITY apiEntity)
        {
            Handler.Update(id, Convert(apiEntity));
        }
    }
}
