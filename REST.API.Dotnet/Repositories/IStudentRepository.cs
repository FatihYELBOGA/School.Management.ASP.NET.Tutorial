using School_Management.Models;

namespace School_Management.Repositories
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Student GetByIdWithCourses(int id);
        List<Student> GetAllWithCourses();
    }
}
