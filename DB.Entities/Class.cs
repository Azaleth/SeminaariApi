using System.Collections.Generic;

namespace Db.Entities
{
    public class Class : BaseDbClass
    {
        public string Subject { get; set; }

        public string Identifier { get; set; }

        public ICollection<LinkStudentClass> Classes { get; set; }
    }
}
