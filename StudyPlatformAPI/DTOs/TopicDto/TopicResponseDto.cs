using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.QuestionDto;

namespace StudyPlatformAPI.DTOs.TopicDto;

public class TopicResponseDto
{
    public int Id { get; set; }

    public int Number { get; set; }

    public string Name { get; set; }

    public int ChapterId { get; set; }

    public ICollection<QuestionResponseDto> Questions { get; set; }
}
