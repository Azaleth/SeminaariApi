using Api.Entities;
using LogicLayer.HandlerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer.Handlers
{
    public class GradeHandler : BaseHandler<Grade, Db.Entities.Grade>, IGradesHandler
    {
        public IEnumerable<Grade> GetStudentGrades(Guid studentId)
        {
            return Convert((Handler as DataAccessLayer.Handlers.GradeDataBaseHandler).GetStudentGrades(studentId));
        }

        public IEnumerable<Grade> GetTeacherGrades(Guid teacherId)
        {
            return Convert((Handler as DataAccessLayer.Handlers.GradeDataBaseHandler).GetTeacherGrades(teacherId));
        }

        internal override Grade Convert(Db.Entities.Grade dbEntity)
        {
            return new Grade()
            {
                Id = dbEntity.Id,
                StudentId = dbEntity.StudentId,               
                ClassId = dbEntity.ClassId,
                TeacherId = dbEntity.TeacherId,
            };
        }

        internal override Db.Entities.Grade Convert(Grade apiEntity)
        {
            return new Db.Entities.Grade()
            {
                Id = apiEntity.Id,
                StudentId = apiEntity.StudentId,
                ClassId = apiEntity.ClassId,
                TeacherId = apiEntity.TeacherId
            };
        }
    }
}
