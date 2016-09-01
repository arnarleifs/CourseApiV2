using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.V2.Models.Entities
{
    [Table("CourseTemplate")]
    public class CourseTemplate
    {
        [Key]
        public string Name { get; set; }
        public string CourseId { get; set; }
    }
}
