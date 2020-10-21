using Db.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public abstract class BaseDataBaseHandler : IDataBaseHandler<BaseDbClass>
    {
        protected SchoolDbContext DbContext => SchoolDbContext.DbContext;
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
            var dbTeacher = DbSet.FirstOrDefault(entity => entity.Id == id);
            if (dbTeacher == null)
                throw new ArgumentException(id.ToString());
            DbContext.Remove(dbTeacher);

        }

        public override IEnumerable<BaseDbClass> Get(int skip, int take)
        {
            return GetDbSet(DbContext).Skip(skip).Take(take).AsEnumerable();
        }

        public override BaseDbClass Get(Guid id)
        {
            DbSet<T> DbSet = GetDbSet(DbContext);
            return DbSet.FirstOrDefault(entity => entity.Id == id);

        }

        public override void Update(Guid id, BaseDbClass dbClass)
        {
            DbSet<T> DbSet = GetDbSet(DbContext);
            var dbTeacher = DbSet.FirstOrDefault(entity => entity.Id == id);
            if (dbTeacher != null)
                DbContext.Remove(dbTeacher);
            DbSet.Add(dbClass as T);
            DbContext.SaveChanges();

        }
    }
}
