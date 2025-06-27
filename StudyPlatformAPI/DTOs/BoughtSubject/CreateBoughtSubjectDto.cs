namespace StudyPlatformAPI.DTOs.BoughtSubject
{
    public class CreateBoughtSubjectDto
    {
        public int SubjectId { get; set; }

        public int UserId { get; set; }
        public string Feedback { get; set; }
    }
}
