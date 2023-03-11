using Microsoft.AspNetCore.Mvc;
using School_Management.DTO;
using School_Management.DTO.Requests;
using School_Management.DTO.Responses;
using School_Management.Models;
using School_Management.Repositories;

namespace School_Management.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController: ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentRepository _studentRepository;
        public CourseController(ICourseRepository courseRepository, IStudentRepository studentRepository){
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
        }

        [HttpGet("all-courses-without-students")]
        public List<CourseResponseDto> GetAllCoursesWithoutStudents()
        {
            List<CourseResponseDto> courses = new List<CourseResponseDto>();
            foreach (Course c in _courseRepository.GetAll())
            {
                courses.Add(ConvertToDto.ConvertToCourseDto(c));
            }
            return courses;
        }

        [HttpGet("all-courses-with-students")]
        public List<CourseResponseDto> GetAllCoursesWithStudents()
        {
            List<CourseResponseDto> courses = new List<CourseResponseDto>();
            foreach (Course c in _courseRepository.GetAllWithStudents())
            {
                courses.Add(ConvertToDto.ConvertToCourseDto(c));
            }
            return courses;
        }

        [HttpPost]
        public CourseResponseDto CreateCourse([FromBody] CourseRequestDto courseRequestDto)
        {
            Course addedCourse = new Course()
            {
                Name = courseRequestDto.Name,
                IsActive = courseRequestDto.IsActive
            };

            return ConvertToDto.ConvertToCourseDto(_courseRepository.Add(addedCourse));
        }

        [HttpPut("{id}")]
        public CourseResponseDto UpdateCourse(int id, [FromBody] CourseRequestDto courseRequestDto)
        {
            Course updatedCourse = new Course()
            {
                Id= id,
                Name = courseRequestDto.Name,
                IsActive = courseRequestDto.IsActive
            };

            return ConvertToDto.ConvertToCourseDto(_courseRepository.Update(updatedCourse));
        }

        [HttpDelete("{id}")]
        public bool DeleteCourseById(int id)
        {
            if (_courseRepository.GetById(id) != null)
            {
                try
                {
                    foreach (Student student in _studentRepository.GetAllWithCourses().ToList())
                    {
                        bool exist = false;
                        if(student.BestCourse != null && student.BestCourse.Id == id)
                        {
                            student.BestCourse = null;
                            exist = true;
                        }
                        if(student.WorstCourse != null && student.WorstCourse.Id == id)
                        {
                            student.WorstCourse = null;
                            exist = true;
                        }
                        if (exist)
                        {
                            _studentRepository.Update(student);
                        }
                    }

                    _courseRepository.DeleteById(id);
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }
    }
}
