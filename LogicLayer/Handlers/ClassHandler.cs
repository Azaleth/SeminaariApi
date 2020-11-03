using Api.Entities;
using DataAccessLayer.Handlers;
using LogicLayer.HandlerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LogicLayer.Handlers
{
    public class ClassHandler : BaseHandler<Class, Db.Entities.Class>, IClassesHandler
    {
        public IEnumerable<Class> GetStudentClasses(Guid studentId)
        {
            return Convert((Handler as ClassDataBaseHandler).GetStudentClasses(studentId));
        }


        public IEnumerable<Class> GetTeacherClasses(Guid teacherId)
        {
            return Convert((Handler as ClassDataBaseHandler).GetTeacherClasses(teacherId));
        }

        internal override Class Convert(Db.Entities.Class dbEntity)
        {
            return new Class()
            {
                Id = dbEntity.Id,
                CourseCode = dbEntity.Identifier,
                Subject = dbEntity.Subject,
                TeacherId = dbEntity.TeacherId,
                StudentIds = dbEntity.StudentIds,
            };
        }

        internal override Db.Entities.Class Convert(Class apiEntity)
        {
            return new Db.Entities.Class()
            {
                Id = apiEntity.Id,
                Identifier = apiEntity.CourseCode,
                Subject = apiEntity.Subject,
                TeacherId = apiEntity.TeacherId,                        
            };
        }
    }
}
