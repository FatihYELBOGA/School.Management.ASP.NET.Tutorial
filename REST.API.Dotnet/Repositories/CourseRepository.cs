using Microsoft.EntityFrameworkCore;
using School_Management.DatabaseConfig;
using School_Management.Models;

namespace School_Management.Repositories
{
    public class CourseRepository: GenericRepository<Course>, ICourseRepository
    {
        private DataContext _dataContext;
        public CourseRepository(DataContext dataContext): base(dataContext)
        {
            _dataContext= dataContext;
        }

        public IQueryable<Course> GetAllWithStudents()
        {
            return _dataContext.courses.
                Include(c => c.BestStudents).
                Include(c => c.WorstStudents).
                Include(c => c.Students)
                .ThenInclude(sc => sc.Student);
        }
    }
}
