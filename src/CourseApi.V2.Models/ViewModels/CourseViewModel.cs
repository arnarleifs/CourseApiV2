using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.V2.Models.ViewModels
{
    /// <summary>
    /// Taken as parameter for updating a course, all properties must be provided
    /// </summary>
    public class CourseViewModel
    {
        [Required]
        public string CourseId { get; set; }
        [Required]
        public int Semester { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int MaxStudents { get; set; }
    }
}
