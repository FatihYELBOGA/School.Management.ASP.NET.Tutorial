using Microsoft.EntityFrameworkCore;
using School_Management.DatabaseConfig;
using School_Management.Models;

namespace School_Management.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private DataContext _dataContext;
        public StudentRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext= dataContext;
        }

        public Student GetByIdWithCourses(int id)
        {
            return _dataContext.students.
                Where(s => s.Id == id).
                Include(s => s.BestCourse).
                Include(s => s.WorstCourse).
                Include(s => s.Courses).
                ThenInclude(sc => sc.Course).
                FirstOrDefault();
        }

        public List<Student> GetAllWithCourses()
        {
            return _dataContext.students.
                Include(s => s.BestCourse).
                Include(s => s.WorstCourse).
                Include(s => s.Courses).
                ThenInclude(sc => sc.Course).ToList();
        }
    }
}
