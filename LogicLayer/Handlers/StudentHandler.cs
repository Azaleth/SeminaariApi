using Api.Entities;
using DataAccessLayer.Handlers;
using LogicLayer.HandlerInterfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LogicLayer.Handlers
{
    internal class StudentHandler : BaseHandler<Student, Db.Entities.Student>, IStudentHandler
    {
        public IEnumerable<Student> GetClassStudents(Guid classId)
        {
            return new StudentHandler().Convert((Handler as StudentDatabaseHandler).GetClassStudents(classId));
        }

        internal override Student Convert(Db.Entities.Student dbEntity)
        {
            return new Student()
            {
                Id = dbEntity.Id,
                BirthDay = dbEntity.BirthDay,
                FirstNames = dbEntity.FirstNames,
                LastName = dbEntity.LastName,
                Classes = dbEntity.ClassIds,
                Grades = dbEntity.GradeIds,
            };
        }

        internal override Db.Entities.Student Convert(Student apiEntity)
        {
            return new Db.Entities.Student()
            {
                Id = apiEntity.Id,
                BirthDay = apiEntity.BirthDay,
                FirstNames = apiEntity.FirstNames,
                LastName = apiEntity.LastName,
            };
        }
    }
}
