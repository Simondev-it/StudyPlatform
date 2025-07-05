using StudyPlatform.Models;

namespace StudyPlatformAPI.DTOs.ChapterProgressDto;

public class CreateChapterProgressDto
{
    public int Score { get; set; }
    public string Note { get; set; }
    public int UserId { get; set; }
    public int ChapterId { get; set; }
}
