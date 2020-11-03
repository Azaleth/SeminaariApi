using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Entities
{
    public class Student : Person
    {
        public IEnumerable<Guid> Grades { get; set; }
        public IEnumerable<Guid> Classes { get; set; }
    }
}
