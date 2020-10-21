using DataAccessLayer.Handlers;
using Db.Entities;
using System;

namespace DataAccessLayer
{
    public class DataBaseHandlerFactory
    {
        public static BaseDataBaseHandler<DaoEntity> GetHandler<DaoEntity>(Type entityType)
            where DaoEntity : BaseDbClass
        {
            if (entityType.IsAssignableFrom(typeof(Class)))
                return new ClassDataBaseHandler() as BaseDataBaseHandler<DaoEntity>;
            else if (entityType.IsAssignableFrom(typeof(Student)))
                return new StudentDatabaseHandler() as BaseDataBaseHandler<DaoEntity>;
            else if (entityType.IsAssignableFrom(typeof(Teacher)))
                return new TeacherDataBaseHandler() as BaseDataBaseHandler<DaoEntity>;
            else if (entityType.IsAssignableFrom(typeof(Grade)))
                return new GradeDataBaseHandler() as BaseDataBaseHandler<DaoEntity>;
            else if (entityType.IsAssignableFrom(typeof(Person)))
                return new PersonDataBaseHandler() as BaseDataBaseHandler<DaoEntity>;
            else
                throw new NotImplementedException();
        }
    }
}
