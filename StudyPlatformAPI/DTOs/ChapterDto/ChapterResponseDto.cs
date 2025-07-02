using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.TopicDto;

namespace StudyPlatformAPI.DTOs.ChapterDto;

public class ChapterResponseDto
{
    public int Id { get; set; }
    public int Number { get; set; }
    public string Name { get; set; }
    public int SubjectId { get; set; }
    public ICollection<TopicResponseDto> Topics { get; set; }
}
