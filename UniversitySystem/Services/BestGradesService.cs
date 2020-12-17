using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversitySystem.Models;

namespace UniversitySystem.Services
{
    public class BestGradesService
    {
        public async Task<IEnumerable<Enrollment>> GetBestGrades(AppDbContext db)
        {
            return await db.Enrollments.Where(e=>e.Grade>17).ToListAsync();
        }
    }
}
