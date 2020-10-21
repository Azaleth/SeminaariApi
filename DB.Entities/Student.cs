using System.Collections.Generic;

namespace Db.Entities
{
    public class Student : Person
    {
        public ICollection<Grade> Grades {get;set;}
        public ICollection<LinkStudentClass> Classes { get; set; }
    }
}
