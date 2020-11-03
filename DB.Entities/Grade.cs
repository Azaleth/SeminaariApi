using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Db.Entities
{
    public class Grade : BaseDbClass
    {
        [Required]
        public int? Score { get; set; }
        [Required]
        [ForeignKey("ClassForeignKey")]
        public Guid ClassId { get; set; }
        [Required]
        [ForeignKey("StudentForeignKey")]
        public Guid StudentId { get; set; }
        [Required]
        [ForeignKey("TeacherForeignKey")]
        public Guid TeacherId { get; set; }
    }
}
