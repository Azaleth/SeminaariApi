using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Db.Entities
{
    public class LinkStudentClass : BaseDbClass
    {
        [Required]
        [ForeignKey("StudentForeignKey")]
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        
        [Required]
        [ForeignKey("ClassForeignKey")]
        public Guid ClassId { get; set; }
        public Class Class { get; set; }
    }
}

