namespace StudyPlatformAPI.DTOs.CommentDto;

public class CommentResponseDto
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int? Answer { get; set; }
    public DateTime? CommentDate { get; set; }
    public int UserId { get; set; }
}
