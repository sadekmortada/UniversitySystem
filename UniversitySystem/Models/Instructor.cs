using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversitySystem.Models
{
    public class Instructor
    {
        [Key]
        public long InstructorID { get; set; }
        [DisplayName("First Name")]
        [Required]
        public string FirstMidName { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }
        public DateTimeOffset HireDate { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual OfficeAssignment OfficeAssignment { get; set; }
    }
}
