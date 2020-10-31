using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public interface IDataInitializer
    {
        void Initialize(SchoolDbContext context);
    }
}
