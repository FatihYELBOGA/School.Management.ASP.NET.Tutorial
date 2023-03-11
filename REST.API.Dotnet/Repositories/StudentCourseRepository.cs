using School_Management.Models;
using School_Management.DatabaseConfig;

namespace School_Management.Repositories
{
    public class StudentCourseRepository : GenericRepository<StudentCourse>, IStudentCourseRepository
    {
        private DataContext _dataContext;
        public StudentCourseRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
