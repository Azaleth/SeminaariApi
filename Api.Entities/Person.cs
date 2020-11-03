using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Entities
{    
    public class Person : BaseEntity
    {
        [Required]
        public string FirstNames { get; set; }
        [Required]
        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }
    }
}
