using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversitySystem.Models
{
    public class Student
    {
        [Key]
        public long StudentID { get; set; }
        [DisplayName("First Name")][Required]
        public string FirstMidName { get; set; }
        [DisplayName("Last Name")][Required]
        public string LastName { get; set; }
        public DateTimeOffset EnrollmentDate { get; set; }  
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
