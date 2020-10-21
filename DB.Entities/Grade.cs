using System;

namespace Db.Entities
{
    public class Grade : BaseDbClass
    {
        public Guid ClassId { get; set; }
        public Guid StudentId { get; set; }
        public Class Class { get; set; }        
    }
}
