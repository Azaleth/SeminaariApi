using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Entities
{
    public class Class : BaseEntity
    {
        [Required]
        [StringLength(25, MinimumLength = 5)]
        public string Subject { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 8)]
        public string CourseCode { get; set; }
        [Required]
        public Guid TeacherId { get; set; }
        public IEnumerable<Guid> StudentIds { get; set; }
    }
}
