namespace StudyPlatformAPI.DTOs.BoughtSubject
{
    public class BoughtSubjectResponseDto
    {
        public int Id { get; set; }

        public DateOnly PurchaseDate { get; set; }

        public string Feedback { get; set; }

        public int SubjectId { get; set; }

        public int UserId { get; set; }
    }
}
