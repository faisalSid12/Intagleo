using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intagleo.Domain
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
