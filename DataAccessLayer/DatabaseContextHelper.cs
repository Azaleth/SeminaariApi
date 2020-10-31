using Db.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;


namespace DataAccessLayer
{
    public class DatabaseContextHelper
    {
        private static SchoolDbContext _schoolDbContext;
        
        public static SchoolDbContext GetSchoolDbContext(IDataInitializer dataInitializer = null)
        {
            if (_schoolDbContext == null)
            {
                DbContextOptions<SchoolDbContext> options;
                var builder = new DbContextOptionsBuilder<SchoolDbContext>();
                builder.UseSqlite(CreateInMemoryDatabase());
                options = builder.Options;
                _schoolDbContext = new SchoolDbContext(options);
                dataInitializer.Initialize(_schoolDbContext);
            }
            return _schoolDbContext;
        }
        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }

    }
}
