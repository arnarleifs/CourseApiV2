using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.V2.Models.Entities
{
    public class StudentRegistry
    {
        public string Ssn { get; set; }
        public int CourseId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
