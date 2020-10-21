using Api.Entities;
using DataAccessLayer.Handlers;
using LogicLayer.HandlerInterfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;

namespace LogicLayer.Handlers
{
    internal class StudentHandler : BaseHandler<Student, Db.Entities.Student>, IStudentHandler
    {
        public IEnumerable<Grade> GetGrades(Guid studentId)
        {
            return new GradeHandler().Convert((Handler as StudentDatabaseHandler).GetGrades(studentId));
        }

        internal override Student Convert(Db.Entities.Student dbEntity)
        {
            return new Student()
            {
                Id = dbEntity.Id,
                BirthDay = dbEntity.BirthDay,
                FirstNames = dbEntity.FirstNames,
                LastName = dbEntity.LastName,
                //Classes = new ClassHandler().Convert(dbEntity.Classes),
                Grades = new GradeHandler().Convert(dbEntity.Grades),
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
