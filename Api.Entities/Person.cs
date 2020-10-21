using System;

namespace Api.Entities
{    
    public class Person : BaseEntity
    {
        public string FirstNames { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }
    }
}
