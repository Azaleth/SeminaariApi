using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Db.Entities
{
    public class Grade : BaseDbClass
    {
        [ForeignKey("ClassForeignKey")]
        public Guid ClassId { get; set; }
        [ForeignKey("StudentForeignKey")]
        public Guid StudentId { get; set; }
        [ForeignKey("TeacherForeignKey")]
        public Guid TeacherId { get; set; }
    }
}
