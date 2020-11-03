using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Db.Entities
{
    public class Student : Person
    {
        public ICollection<Grade> Grades {get;set;}
        public IEnumerable<Guid> GradeIds => Grades?.Select(grade => grade.Id);

        [ForeignKey(nameof(LinkStudentClass.StudentId))]
        public ICollection<LinkStudentClass> Classes { get; set; }
        public IEnumerable<Guid> ClassIds => Classes?.Select(clas => clas.ClassId);
    }
}
