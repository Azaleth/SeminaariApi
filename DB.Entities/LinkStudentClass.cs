using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Db.Entities
{
    public class LinkStudentClass : BaseDbClass
    {
        [ForeignKey("StudentForeignKey")]
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        [ForeignKey("ClassForeignKey")]
        public Guid ClassId { get; set; }
        public Class Class { get; set; }
    }
}

