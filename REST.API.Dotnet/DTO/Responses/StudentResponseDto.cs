using System.Text.Json.Serialization;

namespace School_Management.DTO.Responses
{
    public class StudentResponseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CourseResponseDto? BestCourse { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CourseResponseDto WorstCourse { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<CourseResponseDto>? Courses { get; set; }

    }
}
