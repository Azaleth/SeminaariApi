using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Entities
{
    public class Student : Person
    {
        public IEnumerable<Grade> Grades { get; set; }
        public IEnumerable<Class> Classes { get; set; }
    }
}
