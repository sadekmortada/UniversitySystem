using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversitySystem.Models
{
    public class Course
    {
        [Key]
        public long CourseID { get; set; }
        [MinLength(3)][MaxLength(50)][Required]
        public string Title { get; set; }
        [Range(1, 5)]
        [Required]
        public string Credits { get; set; }
        public virtual Department Department { get; set; }
        public virtual Instructor Instructor { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
