using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.V2.Models.DTO
{
    public class CourseExtendedDto : CourseDto
    {
        public IEnumerable<StudentDto> Students { get; set; }
    }
}
