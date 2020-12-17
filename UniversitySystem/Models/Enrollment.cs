using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading.Tasks;

namespace UniversitySystem.Models
{
    public class Enrollment
    {
        [Key]
        public long enrollmentID { get; set; }
        [Range(0, 20)]
        public double Grade { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }


    }
}
