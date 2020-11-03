using Api.Common.Exceptions;
using DataAccessLayer.Extensions;
using Db.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public abstract class BaseDataBaseHandler : IDataBaseHandler<BaseDbClass>
    {
        protected SchoolDbContext DbContext { get; } = DatabaseContextHelper.GetSchoolDbContext();
        public abstract Guid Add(BaseDbClass iDaoEntity);
        public abstract void Delete(Guid id);
        public abstract IEnumerable<BaseDbClass> Get(int skip, int take);
        public abstract BaseDbClass Get(Guid id);
        public abstract void Update(Guid id, BaseDbClass iDaoEntity);
    }
    public abstract class BaseDataBaseHandler<T> : BaseDataBaseHandler
        where T : BaseDbClass
    {
        protected abstract DbSet<T> GetDbSet(SchoolDbContext context);        
        protected virtual IQueryable<T> AddIncludes(IQueryable<T> queryable)
        {
            return queryable;
        }
        public override Guid Add(BaseDbClass dbClass)
        {
            dbClass.Id = Guid.NewGuid();

            DbSet<T> DbSet = GetDbSet(DbContext);
            DbSet.Add(dbClass as T);
            DbContext.SaveChanges();

            return dbClass.Id;
        }

        public override void Delete(Guid id)
        {
            DbSet<T> DbSet = GetDbSet(DbContext);
            var dbEntity = DbSet.GetWithCheck(id);
            DbContext.Remove(dbEntity);
            DbContext.SaveChanges();
        }

        public override IEnumerable<BaseDbClass> Get(int skip, int take)
        {
            return AddIncludes(GetDbSet(DbContext).Skip(skip).Take(take)).AsEnumerable();
        }

        public override BaseDbClass Get(Guid id)
        {
            DbSet<T> DbSet = GetDbSet(DbContext);
            var dbEntity = DbSet.GetWithCheck(id);
            return dbEntity;
        }

        public override void Update(Guid id, BaseDbClass dbClass)
        {
            DbSet<T> DbSet = GetDbSet(DbContext);
            var dbEntity = DbSet.FirstOrDefault(entity => entity.Id == id);
            if (dbEntity != null)
                DbContext.Remove(dbEntity);
            DbSet.Add(dbClass as T);
            DbContext.SaveChanges();
        }
        
    }
}
