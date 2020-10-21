using Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Handlers
{
    public class TeacherDataBaseHandler : BaseDataBaseHandler<Teacher>
    {
        protected override DbSet<Teacher> GetDbSet(SchoolDbContext context)
        {
            return context.Teachers;
        }
    }
}
