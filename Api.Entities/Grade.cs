using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities
{
    public class Grade : BaseEntity
    {
        public Class Class { get; set; }
    }
}
