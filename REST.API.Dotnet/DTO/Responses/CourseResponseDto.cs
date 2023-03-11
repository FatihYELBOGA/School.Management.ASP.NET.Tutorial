using System.Text.Json.Serialization;

namespace School_Management.DTO.Responses
{
    public class CourseResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<StudentResponseDto>? BestStudents { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<StudentResponseDto>? WorstStudents { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<StudentResponseDto>? Students { get; set; }

    }
}
