using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseApi.V2.Models.Entities
{
    [Table("Course")]
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string CourseId { get; set; }
        public int Semester { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
