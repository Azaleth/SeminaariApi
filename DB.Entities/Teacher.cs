using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Db.Entities
{ 
    public class Teacher : Person
    {
        public IEnumerable<Class> Classes { get; set; }
    }
}
