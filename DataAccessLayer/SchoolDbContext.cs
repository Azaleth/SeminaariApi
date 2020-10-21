using Db.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace DataAccessLayer
{
    public class SchoolDbContext : DbContext
    {
        private static SchoolDbContext _dbContext;
        internal static SchoolDbContext DbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    DbContextOptions<SchoolDbContext> options;
                    var builder = new DbContextOptionsBuilder<SchoolDbContext>();
                    builder.UseSqlite(CreateInMemoryDatabase());
                    options = builder.Options;
                    _dbContext = new SchoolDbContext(options);
                    DataInitializer.Initialize(_dbContext);                    
                }
                return _dbContext;
            }
        }
        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }
        
        internal DbSet<Class> Classes { get; set; }
        internal DbSet<Grade> Grades { get; set; }
        internal DbSet<Person> Persons { get; set; }
        internal DbSet<Student> Students { get; set; }
        internal DbSet<Teacher> Teachers { get; set; }
    }
}
