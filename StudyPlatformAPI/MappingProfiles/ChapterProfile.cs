using AutoMapper;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.ChapterDto;

namespace StudyPlatformAPI.MappingProfiles;

public class ChapterProfile : Profile
{
    public ChapterProfile()
    {
        CreateMap<Chapter, ChapterResponseDto>();
    }
}
