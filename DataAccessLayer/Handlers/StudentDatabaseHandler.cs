using Db.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Handlers
{
    public class StudentDatabaseHandler : BaseDataBaseHandler<Student>
    {
        protected override DbSet<Student> GetDbSet(SchoolDbContext context)
        {
            return context.Students;
        }
        public IEnumerable<Grade> GetGrades(Guid studentId)
        {
            return DbContext.Students
                .Include(nameof(Student.Grades))
                .Single(student => student.Id == studentId)
                .Grades;
        }
    }
}

