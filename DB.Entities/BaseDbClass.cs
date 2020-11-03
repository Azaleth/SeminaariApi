using System;
using System.ComponentModel.DataAnnotations;

namespace Db.Entities
{
    public class BaseDbClass 
    {
        [Required]
        public Guid Id { get; set; }
    }
}
