using Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Handlers
{
    public class ClassDataBaseHandler : BaseDataBaseHandler<Class>
    {
        protected override DbSet<Class> GetDbSet(SchoolDbContext context)
        {
            return context.Classes;
        }
    }
}
