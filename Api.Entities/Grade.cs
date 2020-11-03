using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities
{
    public class Grade : BaseEntity
    {
        public Guid ClassId { get; set; }
        public Guid TeacherId { get; set; }
        public Guid StudentId { get; set; }
    }
}
