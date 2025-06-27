
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.ProgressDto;

namespace StudyPlatformAPI.DTOs.BoughtSubjectDto;

public class BoughtSubjectResponseDto
{
    public int Id { get; set; }

    public DateOnly PurchaseDate { get; set; }

    public string Feedback { get; set; }

    public int SubjectId { get; set; }

    public int UserId { get; set; }

    public ProgressResponseDto Progress { get; set; }
}
