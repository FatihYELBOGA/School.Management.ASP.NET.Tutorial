using School_Management.DTO.Responses;
using School_Management.Models;

namespace School_Management.DTO
{
    public static class ConvertToDto
    {
        public static StudentResponseDto ConvertToStudentDto(Student student)
        {
            CourseResponseDto bestCourses = null;
            CourseResponseDto worstCourses = null;
            List<CourseResponseDto> courses = null;

            if(student.BestCourse != null)
            {
                bestCourses = new CourseResponseDto()
                {
                    Id = student.BestCourse.Id,
                    Name = student.BestCourse.Name,
                    IsActive= student.BestCourse.IsActive
                };
            }
            if(student.WorstCourse != null)
            {
                worstCourses = new CourseResponseDto()
                {
                    Id = student.WorstCourse.Id,
                    Name = student.WorstCourse.Name,
                    IsActive= student.WorstCourse.IsActive
                };
            }
            if(student.Courses != null && student.Courses.Count() > 0)
            {
                courses = new List<CourseResponseDto>();
                foreach (StudentCourse sc in student.Courses)
                {
                    courses.Add(ConvertToCourseDto(new Course()
                    {
                        Id = sc.Course.Id,
                        Name = sc.Course.Name,
                        IsActive = sc.Course.IsActive
                    }));
                }
            }

            return new StudentResponseDto()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                BestCourse = bestCourses,
                WorstCourse = worstCourses,
                Courses = courses
            };
        }

        public static CourseResponseDto ConvertToCourseDto(Course course)
        {
            List<StudentResponseDto> bestStudents = null;
            List<StudentResponseDto> worstStudents = null;
            List<StudentResponseDto> students = null;

            if(course.BestStudents != null && course.BestStudents.Count() > 0)
            {
                bestStudents = new List<StudentResponseDto>();
                foreach (Student s in course.BestStudents)
                {
                    bestStudents.Add(new StudentResponseDto()
                    {
                        Id = s.Id,
                        FirstName = s.FirstName,
                        LastName = s.LastName
                    });
                }
            }
            if(course.WorstStudents != null && course.WorstStudents.Count() > 0)
            {
                worstStudents = new List<StudentResponseDto>();
                foreach (Student s in course.WorstStudents)
                {
                    worstStudents.Add(new StudentResponseDto()
                    {
                        Id = s.Id,
                        FirstName = s.FirstName,
                        LastName = s.LastName
                    });
                }
            }
            if(course.Students != null && course.Students.Count() > 0)
            {
                students = new List<StudentResponseDto>();
                foreach (StudentCourse sc in course.Students)
                {
                    students.Add(ConvertToStudentDto(new Student()
                    {
                        Id = sc.Student.Id,
                        FirstName = sc.Student.FirstName,
                        LastName = sc.Student.LastName
                    }));
                }
            }

            return new CourseResponseDto()
            {
                Id = course.Id,
                Name = course.Name,
                IsActive= course.IsActive,
                BestStudents = bestStudents,
                WorstStudents = worstStudents,
                Students = students
            };
        }
    }
}
