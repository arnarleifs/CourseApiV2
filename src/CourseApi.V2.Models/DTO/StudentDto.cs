using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.V2.Models.DTO
{
    /// <summary>
    /// Data transfer object for student representation
    /// </summary>
    public class StudentDto
    {
        public string Ssn { get; set; }
        public string Name { get; set; }
    }
}
