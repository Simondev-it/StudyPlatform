using StudyPlatform.Models;

namespace StudyPlatformAPI.DTOs.SubjectDto;

public class SubjectResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public int Price { get; set; }

    public DateOnly? UploadDate { get; set; }

    public DateOnly? LastEditDate { get; set; }
}
