namespace StudyPlatformAPI.DTOs.FollowingDto;

public class FollowingResponseDto
{
    public int Id { get; set; }
    public DateOnly? FollowDate { get; set; }
    public int FollowingId { get; set; }
    public int UserId { get; set; }
}
