using Microsoft.EntityFrameworkCore;
using School_Management.Models;

namespace School_Management.DatabaseConfig
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Student> students { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<StudentCourse> studentscourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().
                HasOne(s => s.BestCourse).
                WithMany(c => c.BestStudents).
                HasForeignKey(s => s.BestCourseId).
                OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Student>().
                HasOne(s => s.WorstCourse).
                WithMany(c => c.WorstStudents).
                HasForeignKey(s => s.WorstCourseId).
                OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<StudentCourse>().
                HasOne(sc => sc.Student).
                WithMany(s => s.Courses).
                HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>().
                HasOne(sc => sc.Course).
                WithMany(c => c.Students).
                HasForeignKey(sc => sc.CourseId);
        }
    }
}
