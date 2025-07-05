using StudyPlatform.Models;

namespace StudyPlatformAPI.DTOs.ChapterProgressDto;

public class ChapterProgressResponseDto
{
    public int Id { get; set; }
    public int Score { get; set; }
    public DateOnly? StartDate { get; set; }
    public string Note { get; set; }
    public int UserId { get; set; }
    public int ChapterId { get; set; }
}
