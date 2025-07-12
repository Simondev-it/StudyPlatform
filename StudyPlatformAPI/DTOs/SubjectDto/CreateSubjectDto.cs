using StudyPlatform.Models;

namespace StudyPlatformAPI.DTOs.SubjectDto;

public class CreateSubjectDto
{
    public string Name { get; set; }
    public string Image { get; set; }
    public int Price { get; set; }
}
