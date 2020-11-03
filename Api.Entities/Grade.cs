using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Entities
{
    public class Grade : BaseEntity
    {
        [Required]
        public int? Score { get; set; }
        [Required]
        public Guid ClassId { get; set; }
        [Required]
        public Guid TeacherId { get; set; }
        [Required]
        public Guid StudentId { get; set; }
    }
}
