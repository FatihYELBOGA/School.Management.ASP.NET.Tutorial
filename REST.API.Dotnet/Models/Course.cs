using School_Management.Models;

namespace School_Management.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Student> BestStudents { get; set; }
        public ICollection<Student> WorstStudents { get; set; }
        public ICollection<StudentCourse> Students { get; set; }

    }
}
