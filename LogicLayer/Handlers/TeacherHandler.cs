using Api.Entities;
using LogicLayer.HandlerInterfaces;
using System.Collections.Generic;

namespace LogicLayer.Handlers
{
    public class TeacherHandler : BaseHandler<Teacher,Db.Entities.Teacher>, ITeacherHandler
    {
        public IEnumerable<Class> GetClasses()
        {
            throw new System.NotImplementedException();
        }

        internal override Teacher Convert(Db.Entities.Teacher dbEntity)
        {
            return new Teacher()
            {
                Id = dbEntity.Id,
                BirthDay = dbEntity.BirthDay,
                FirstNames = dbEntity.FirstNames,
                LastName = dbEntity.LastName,
            };
        }

        internal override Db.Entities.Teacher Convert(Teacher apiEntity)
        {
            return new Db.Entities.Teacher()
            {
                Id = apiEntity.Id,
                BirthDay = apiEntity.BirthDay,
                FirstNames = apiEntity.FirstNames,
                LastName = apiEntity.LastName,
            };
        }
    }
}
