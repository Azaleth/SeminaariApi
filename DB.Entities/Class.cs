using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Db.Entities
{
    public class Class : BaseDbClass
    {
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Identifier { get; set; }
        [Required]
        [ForeignKey("TeacherForeignKey")]
        public Guid TeacherId { get; set; }
        [ForeignKey(nameof(LinkStudentClass.ClassId))]
        public ICollection<LinkStudentClass> Students { get; set; }
        public IEnumerable<Guid> StudentIds => Students?.Select(student => student.Id);
    }
}
