using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversitySystem.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> p) : base(p){}
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            model.Entity<Course>(entity =>
            {
                entity.HasMany(e => e.Enrollments).WithOne(e => e.Course).OnDelete(DeleteBehavior.Cascade);
            });
            model.Entity<Instructor>(entity =>
            {
                entity.HasMany(e => e.Courses).WithOne(e => e.Instructor).OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(e => e.Departments).WithOne(e => e.Instructor).OnDelete(DeleteBehavior.SetNull);
                entity.HasOne(e => e.OfficeAssignment).WithOne(e => e.Instructor).OnDelete(DeleteBehavior.Cascade);
            });
            model.Entity<Department>(entity =>
            {
                entity.HasMany(e => e.Courses).WithOne(e => e.Department).OnDelete(DeleteBehavior.Cascade);
            });
            model.Entity<Student>(entity => {
                entity.HasMany(e => e.Enrollments).WithOne(e => e.Student).OnDelete(DeleteBehavior.Cascade);
            });
        }

    }
}
