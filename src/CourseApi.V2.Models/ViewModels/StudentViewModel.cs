using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.V2.Models.ViewModels
{
    /// <summary>
    /// Used to add a student to a course
    /// </summary>
    public class StudentViewModel
    {
        public string Ssn { get; set; }
        public string Name { get; set; }
    }
}
