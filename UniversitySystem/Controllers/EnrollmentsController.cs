using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Models;
using UniversitySystem.Services;

namespace UniversitySystem.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly AppDbContext _context;
        private EnrollmentViewModel Evm;
        private readonly BestGradesService bestGradesService;

        public EnrollmentsController(AppDbContext context,BestGradesService bestGradesService)
        {
            _context = context;
            this.bestGradesService = bestGradesService;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index()
        {
            IEnumerable<Enrollment> Enrollments = await _context.Enrollments.ToListAsync();
            
            return View(Enrollments);
        }

        // GET: Enrollments/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments
                .FirstOrDefaultAsync(m => m.enrollmentID == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // GET: Enrollments/Create
        public IActionResult Create()
        {
            Evm = new EnrollmentViewModel()
            {
                Students = new List<SelectListItem>(),
                Courses = new List<SelectListItem>()
            };

            foreach (Student s in _context.Students)
                ((List<SelectListItem>)Evm.Students).Add(new SelectListItem()
                {
                    Text = s.StudentID.ToString(),
                    Value = s.StudentID.ToString()
                });

            foreach (Course c in _context.Courses)
                ((List<SelectListItem>)Evm.Courses).Add(new SelectListItem()
                {
                    Text = c.CourseID.ToString(),
                    Value = c.CourseID.ToString()
                });
            return View(Evm);
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(long SelectedStudent, IEnumerable<long> SelectedCourses)
        {

            Student S = await _context.Students.FindAsync(SelectedStudent);
           
            foreach(long s in SelectedCourses)
            {
                Enrollment E = new Enrollment
                {
                    Student = S,
                    Course = await _context.Courses.FindAsync(s),
                    Grade = -1
                };
                if (await _context.Enrollments.Where(i=>i.Student==S).Where(i=>i.Course==E.Course).FirstOrDefaultAsync()==default)
                    await _context.Enrollments.AddAsync(E);
            }
            await _context.SaveChangesAsync();
            return Redirect("Index");
        }

        // GET: Enrollments/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("enrollmentID,Grade")] Enrollment enrollment)
        {
            if (id != enrollment.enrollmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentExists(enrollment.enrollmentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments
                .FirstOrDefaultAsync(m => m.enrollmentID == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(long id)
        {
            return _context.Enrollments.Any(e => e.enrollmentID == id);
        }
        [HttpGet]
        public async Task<IActionResult> BestGrades()
        {
            return View(await bestGradesService.GetBestGrades(_context));
        }
    }
}
