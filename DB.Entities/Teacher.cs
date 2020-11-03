using System.Collections.Generic;

namespace Db.Entities
{
    public class Teacher : Person
    {
        public IEnumerable<Class> Classes { get; set; }
    }
}
