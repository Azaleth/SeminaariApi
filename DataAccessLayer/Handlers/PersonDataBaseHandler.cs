using Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Handlers
{
    public class PersonDataBaseHandler : BaseDataBaseHandler<Person>
    {
        protected override DbSet<Person> GetDbSet(SchoolDbContext context)
        {
            return context.Persons;
        }
    }
}
