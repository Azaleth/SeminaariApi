using Db.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Handlers
{
    public class StudentDatabaseHandler : BaseDataBaseHandler<Student>
    {
        protected override IQueryable<Student> AddIncludes(IQueryable<Student> queryable)
        {
            return queryable.Include(nameof(Student.Classes)).Include(nameof(Student.Grades));
        }
        protected override DbSet<Student> GetDbSet(SchoolDbContext context)
        {
            return context.Students;
        }
        public IEnumerable<Student> GetClassStudents(Guid classId)
        {
            return DbContext.LinkStudentClasses
                .Include(nameof(LinkStudentClass.Student))
                .Where(link => link.ClassId == classId)
                .Select(link => link.Student);
        }
    }
}

