using System;
using System.ComponentModel.DataAnnotations;

namespace Db.Entities
{
    public class Person : BaseDbClass
    {
        [Required]
        public string FirstNames { get; set; }
        [Required]
        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }
    }
}
