using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversitySystem.Models
{
    public class Department
    {
        [Key]
        public long DepartmentID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Budget { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
