namespace School_Management.DTO.Requests
{
    public class StudentRequestDto
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int? BestCourseId { get; set; }
        public int? WorstCourseId { get; set; }

    }
}
