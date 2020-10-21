using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Entities
{
    public class BaseEntity
    {
        [Required]
        public Guid Id { get; set; }
    }
}
