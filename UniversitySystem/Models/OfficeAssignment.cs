using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversitySystem.Models
{
    public class OfficeAssignment
    { 
        [Key]
        public long OfficeAssignmentID { get; set; }
        [Required]
        public string Location { get; set; }
        public  long InstructorID{ get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}
