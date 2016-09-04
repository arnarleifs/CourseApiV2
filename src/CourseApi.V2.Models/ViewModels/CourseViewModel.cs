using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.V2.Models.ViewModels
{
    /// <summary>
    /// Taken as parameter for updating a course, all properties must be provided
    /// </summary>
    public class CourseViewModel
    {
        public string CourseId { get; set; }
        public int Semester { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
