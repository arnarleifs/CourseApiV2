using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.V2.Models.Entities
{
    public class WaitingList
    {
        [Key]
        public int CourseId { get; set; }
        [Key]
        public string Ssn { get; set; }
    }
}
