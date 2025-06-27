using StudyPlatform.Models;

namespace StudyPlatformAPI.DTOs.TopicProgress
{
    public class TopicProgressCreateDTO
    {
         
        //public int id { get; set; }
        public int Score { get; set; }

        public DateOnly? StartDate { get; set; }

        public int UserId { get; set; }

        public int TopicId { get; set; }

        
    }
}
