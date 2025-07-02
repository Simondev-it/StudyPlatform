using StudyPlatform.Models;

namespace StudyPlatformAPI.DTOs.QuestionDto;

public class QuestionResponseDto
{
    public int Id { get; set; }

    public int Number { get; set; }

    public string Type { get; set; }

    public string Question1 { get; set; }

    public string CorrectAnswer { get; set; }

    public string Answers { get; set; }

    public string Explanation { get; set; }

    public string Note { get; set; }

    public int TopicId { get; set; }
}
