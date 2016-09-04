using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.V2.Models.DTO
{
    /// <summary>
    /// An extended CourseDto, used to preview a list of students in the given course
    /// </summary>
    public class CourseExtendedDto : CourseDto
    {
        public string Name { get; set; }
        public IEnumerable<StudentDto> Students { get; set; }
    }
}
