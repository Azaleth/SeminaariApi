using DataAccessLayer;
using NUnit.Framework;
using System;

namespace Api.UnitTests
{
    internal abstract class UnitTestBase
    {
        protected abstract IDataInitializer DataInitializer { get; }
        protected SchoolDbContext Context { get; private set; }
        [SetUp]
        public void Setup()
        {
            Context = DatabaseContextHelper.GetSchoolDbContext(DataInitializer);
        }
    }
}
