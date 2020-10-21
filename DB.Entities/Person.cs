using System;

namespace Db.Entities
{
    public class Person : BaseDbClass
    {
        public string FirstNames { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }
    }
}
