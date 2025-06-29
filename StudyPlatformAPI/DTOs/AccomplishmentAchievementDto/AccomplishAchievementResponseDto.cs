namespace StudyPlatformAPI.DTOs.AccomplishmentAchievementDto;

public class AccomplishAchievementResponseDto
{
    public int Id { get; set; }
    public int Progress { get; set; }
    public DateOnly? AchieveDate { get; set; }
    public int Status { get; set; }
    public int AchievementId { get; set; }
    public int UserId { get; set; }
}
