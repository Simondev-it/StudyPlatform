namespace StudyPlatformAPI.DTOs.TopicProgress
{
    public class TopicProgressResponseDTO
    {
        public int id { get; set; }
        public int Score { get; set; }
        public string Note { get; set; }
        public DateTime? StartDate { get; set; }
        public int UserId { get; set; }
        public int TopicId { get; set; }
    }
}
