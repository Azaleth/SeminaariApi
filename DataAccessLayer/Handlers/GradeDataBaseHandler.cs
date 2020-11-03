using Db.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Handlers
{
    public class GradeDataBaseHandler : BaseDataBaseHandler<Grade>
    {
        protected override DbSet<Grade> GetDbSet(SchoolDbContext context)
        {
            return context.Grades;
        }
        public IEnumerable<Grade> GetStudentGrades(Guid studentId)
        {
            return DbContext.Grades.Where(grade => grade.StudentId == studentId);
        }
        public IEnumerable<Grade> GetTeacherGrades(Guid teacherId)
        {
            return DbContext.Grades.Where(grade => grade.TeacherId == teacherId);
        }
    }
}
