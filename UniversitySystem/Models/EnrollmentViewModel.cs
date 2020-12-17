using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversitySystem.Models
{
    public class EnrollmentViewModel
    {
        public IEnumerable<SelectListItem> Students { get; set; }
        public IEnumerable<SelectListItem> Courses { get; set; }
        public long SelectedStudent { get; set; }
        public IEnumerable<long> SelectedCourses { get; set; }
    }
}
