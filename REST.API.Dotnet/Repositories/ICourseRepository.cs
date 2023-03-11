using School_Management.Models;

namespace School_Management.Repositories
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        IQueryable<Course> GetAllWithStudents();
    }
}
