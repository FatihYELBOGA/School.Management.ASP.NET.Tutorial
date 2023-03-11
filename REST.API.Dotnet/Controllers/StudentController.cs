using Microsoft.AspNetCore.Mvc;
using School_Management.DTO;
using School_Management.DTO.Requests;
using School_Management.DTO.Responses;
using School_Management.Repositories;
using School_Management.Models;

namespace School_Management.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController: ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentCourseRepository _studentCourseRepository;
        private readonly ICourseRepository _courseRepository;
        public StudentController(IStudentRepository studentRepository, IStudentCourseRepository studentCourseRepository, ICourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _studentCourseRepository = studentCourseRepository;
            _courseRepository = courseRepository;
        }

        [HttpGet("all-students-with-courses")]
        public List<StudentResponseDto> GetAllStudentsWithCourses()
        { 
            List<StudentResponseDto> students = new List<StudentResponseDto>();
            foreach (Student s in _studentRepository.GetAllWithCourses())
            {
                students.Add(ConvertToDto.ConvertToStudentDto(s));
            }
            return students;
        }

        [HttpPost]
        public StudentResponseDto CreateStudent([FromBody] StudentRequestDto studentRequestDto)
        {
            Student addedStudent = new Student()
            {
                FirstName = studentRequestDto.FirstName,
                LastName = studentRequestDto.LastName,
                BestCourseId =(int) studentRequestDto.BestCourseId,
                WorstCourseId =(int) studentRequestDto.WorstCourseId
            };

            int addedStudentId = _studentRepository.Add(addedStudent).Id;

            return ConvertToDto.ConvertToStudentDto(_studentRepository.GetByIdWithCourses(addedStudentId));
        }

        [HttpPut("{id}")]
        public StudentResponseDto UpdateStudent(int id, [FromBody] StudentRequestDto studentRequestDto)
        {
            Student updatedStudent = new Student()
            {
                Id = id,
                FirstName = studentRequestDto.FirstName,
                LastName = studentRequestDto.LastName,
            };

            if (studentRequestDto.BestCourseId != null)
            {
                updatedStudent.WorstCourse = _courseRepository.GetById((int) studentRequestDto.BestCourseId);
            }
            if(studentRequestDto.WorstCourseId != null)
            {
                updatedStudent.BestCourse = _courseRepository.GetById((int)studentRequestDto.WorstCourseId);
            }

            int updatedStudentId = _studentRepository.Update(updatedStudent).Id;

            return ConvertToDto.ConvertToStudentDto(_studentRepository.GetByIdWithCourses(updatedStudentId));
        }

        [HttpPut("add-course/{id}")]
        public StudentResponseDto AddCourseToStudent(int id, [FromQuery] int courseId)
        {
            _studentCourseRepository.Add(new StudentCourse()
            {
                StudentId = id,
                CourseId = courseId
            });

            return ConvertToDto.ConvertToStudentDto(_studentRepository.GetByIdWithCourses(id));
        }

        [HttpPut("remove-course/{id}")]
        public StudentResponseDto RemoveCourseFromStudent(int id, [FromQuery] int courseId)
        {
            foreach (StudentCourse sc in _studentCourseRepository.GetAll())
            {
                if(sc.StudentId == id && sc.CourseId == courseId)
                {
                    _studentCourseRepository.DeleteByEntity(sc);
                }
            }

            return ConvertToDto.ConvertToStudentDto(_studentRepository.GetByIdWithCourses(id));
        }

        [HttpDelete("{id}")]
        public bool DeleteStudentById(int id)
        {
            if(_studentRepository.GetById(id) != null)
            {
                try{
                    _studentRepository.DeleteById(id);
                    return true;
                }
                catch{
                    return false;
                }
            }

            return false;
        }
    }
}
