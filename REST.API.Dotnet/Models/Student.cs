using School_Management.Models;

namespace School_Management.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? BestCourseId { get; set; }
        public Course? BestCourse { get; set; }
        public int? WorstCourseId { get; set; }
        public Course? WorstCourse { get; set; }
        public ICollection<StudentCourse> Courses { get; set; }

    }
}
