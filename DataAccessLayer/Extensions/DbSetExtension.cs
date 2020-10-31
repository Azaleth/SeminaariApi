using Api.Common.Exceptions;
using Db.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DataAccessLayer.Extensions
{
    public static class DbSetExtension
    {
        public static T GetWithCheck<T>(this DbSet<T> dbSet, Guid id)
             where T : BaseDbClass
        {
            var dbEntity = dbSet.FirstOrDefault(entity => entity.Id == id);
            if (dbEntity == null)
                throw new NotFoundException(id.ToString());
            return dbEntity;
        }
    }
}
