using Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Handlers
{
    public class GradeDataBaseHandler : BaseDataBaseHandler<Grade>
    {
        protected override DbSet<Grade> GetDbSet(SchoolDbContext context)
        {
            return context.Grades;
        }
    }
}
