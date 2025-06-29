namespace StudyPlatformAPI.DTOs.CommentDto;

public class CreateCommentDto
{
    public string Content { get; set; }
    public int Answer { get; set; }
    public int QuestionId { get; set; }
    public int UserId { get; set; }
}
