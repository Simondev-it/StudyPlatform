namespace StudyPlatformAPI.DTOs
{
    public class BoughtSubjectDto
    {
        public int Id { get; set; }

        public DateOnly PurchaseDate { get; set; }

        public string Feedback { get; set; }

        public int SubjectId { get; set; }

        public int UserId { get; set; }
    }
}
