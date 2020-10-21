using System;

namespace Db.Entities
{
    public class LinkStudentClass : BaseDbClass
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public Guid ClassId { get; set; }
        public Class Class { get; set; }
    }
}

