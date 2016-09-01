using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseApi.V2.Models.Entities
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public string Ssn { get; set; }
        public string Name { get; set; }
    }
}
