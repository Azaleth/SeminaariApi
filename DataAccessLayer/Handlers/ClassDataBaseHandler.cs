using Db.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Handlers
{
    public class ClassDataBaseHandler : BaseDataBaseHandler<Class>
    {
        protected override IQueryable<Class> AddIncludes(IQueryable<Class> queryable)
        {
            return queryable.Include(nameof(Class.Students));
        }
        protected override DbSet<Class> GetDbSet(SchoolDbContext context)
        {
            return context.Classes;
        }
        public IEnumerable<Class> GetStudentClasses(Guid studentId)
        {
            return DbContext.LinkStudentClasses
                .Include(nameof(LinkStudentClass.Class))
                .Where(link => link.StudentId == studentId)
                .Select(link => link.Class);
        }
        public IEnumerable<Class> GetTeacherClasses(Guid teacherId)
        {
            return DbContext.Classes
                .Where(clas => clas.TeacherId == teacherId);
        }
    }
}
