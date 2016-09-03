using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.V2.Models.DTO
{
    /// <summary>
    /// Data transfer object representing the Course object
    /// </summary>
    public class CourseDto
    {
        public string CourseId { get; set; }
        public int Semester { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfStudents { get; set; }
    }
}
